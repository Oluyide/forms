using Dapper;
using FormCore.Models;
using HappinessForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappinessForm.Controllers
{
    public class BillingController : Controller
    {
        private readonly HappinessFormContext _db = new HappinessFormContext();
        public static string constr = ConfigurationManager.ConnectionStrings["DashboardContext"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        // GET: Billing

        [HttpGet]
        public ActionResult BillinProcess()
        {
            SurgicalInfo model = new SurgicalInfo();


            DateTime start=DateTime.Today;
            DateTime end=DateTime.Today;
            var getPatList = SurgeryReport(start,end);

            model.ListOfEntries = getPatList;



            return View(model);
        }

        [HttpPost]
        public ActionResult BillinProcess(SurgicalInfo model)
        {
           
            var getPatList = SurgeryReport(model.Start, model.End);

            model.ListOfEntries = getPatList;



            return View(model);
        }

        public List<SurgicalInfo> SurgeryReport(DateTime start,DateTime end)
        {
            //var objMTDDetails = SqlMapper.QueryMultiple(con, "RunningPayorMixMTDCountVsRevenueOPDPost", new { facilityId = facilities, endTime = DateTime.Parse(End) }, null, null, commandType: CommandType.StoredProcedure);
            var objDetails = SqlMapper.QueryMultiple(con, "SurgeryReport", new {start = start, end = end }, null, null, commandType: CommandType.StoredProcedure);

          
            var t = objDetails.Read<SurgicalInfo>().ToList();
            return t;
        }


        public ActionResult Details(int Id)
        {
            var objDetails = SqlMapper.QueryMultiple(con, "DetailSurgeryInfo", new { Id = Id }, null, null, commandType: CommandType.StoredProcedure);
            var t = objDetails.Read<SurgicalInfo>().ToList();
           
            SurgicalInfo model= new SurgicalInfo();
            model.ListofLabTest = LabInvest(Id);
            model.Beds = GetBeds();
            foreach (var x in t)
            {
                model.PatientName = x.PatientName;
                model.hospitalNo = x.hospitalNo;
                model.Gender = x.Gender;
                model.Age = x.Age;
                model.ProcedureText = x.ProcedureText;
                model.consultantIncharge = x.consultantIncharge;
                model.AddmisionDate = x.AddmisionDate;
                model.ProcedureDate = x.ProcedureDate;

                model.Diagnosis = x.Diagnosis;
                model.surgeryclassID = x.surgeryclassID;
                model.AnathesiaListId = x.AnathesiaListId;
                model.TheatreListId = x.TheatreListId;
                model.FirstName = x.FirstName;
                model.LastName = x.LastName;
                model.Diagnosistext = x.Diagnosistext;
                model.CoexistingMedConditions = x.CoexistingMedConditions;
                model.SpecialRequirement = x.SpecialRequirement;
                model.CurrentMedication = x.CurrentMedication;
                model.BedID = x.BedID;
                
                model.Beddays = x.Beddays;
                model.BedCost = x.BedCost;

                model.surgeryclassID = x.surgeryclassID;
                model.surgeryCost = x.surgeryCost;

                model.AnathesiaListId = x.AnathesiaListId;
                model.AnathesiaCost = x.AnathesiaCost;

                model.TheatreListId = x.TheatreListId;
                model.TheatreCost = x.TheatreCost;

            }
            return View(model);


        }

        public List<SelectListItem> GetBeds()
        {
            using (StreamReader r = new StreamReader(Server.MapPath("~/JsonFiles/Beds.json")))
            {
                using (JsonTextReader reader = new JsonTextReader(r))
                {
                    reader.SupportMultipleContent = true;
                    JsonSerializer serializer = new JsonSerializer();
                    List<SelectListItem> items = serializer.Deserialize<List<SelectListItem>>(reader);
                    return items;
                }
            }

        }

        public List<Investigations> LabInvest(int Id)
        {
            //var objMTDDetails = SqlMapper.QueryMultiple(con, "RunningPayorMixMTDCountVsRevenueOPDPost", new { facilityId = facilities, endTime = DateTime.Parse(End) }, null, null, commandType: CommandType.StoredProcedure);
            var objDetails = SqlMapper.QueryMultiple(con, "labInvestperPatientPerId", new { Id = Id }, null, null, commandType: CommandType.StoredProcedure);

            Investigations k = new Investigations();
            var t = objDetails.Read<Investigations>().ToList();
            return t;
        }


        

    }
}