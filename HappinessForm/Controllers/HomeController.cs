using Dapper;
using FormCore.Models;
using HappinessForm.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace HappinessForm.Controllers
{


    //[Authorize]
    public class HomeController : Controller
    {
        private readonly HappinessFormContext _db = new HappinessFormContext();
        public static string constr = ConfigurationManager.ConnectionStrings["DashboardContext"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        [HttpGet]
        public ActionResult Index()
        {
            SurgicalInfo model =new SurgicalInfo();
            model.AddmisionDate = DateTime.Today.ToShortDateString();
            model.ProcedureDate = DateTime.Today.ToShortDateString();

            //model.Doctors = GetSelectListItems();
            //model.DiagnosisCount = GetDiagnosisListItems();
            //model.Procedures = GetProcedureListItems();
            //model.Beds = GetBedCategoryListItems();
            //model.surgeryClasses = GetSurgeryClassList();

            //model.investigations = GetLabInvestigationsItems();

            model.Doctors = GetDoctorsList();
            //model.DiagnosisCount = GetDiagnosisList();
            model.Procedures = GetProcedures();
            model.Beds = GetBeds();
            model.surgeryClasses = GetSurgeryClasses();
            model.investigations = GetInvestigations();

            //model.GenderList.Add(new SelectListItem { Text = "Select Gender", Value = "0" });
            model.GenderList.Add(new SelectListItem { Text = "Male", Value = "Male" });
            model.GenderList.Add(new SelectListItem { Text = "Female", Value = "Female" });


            //model.AnathesiaList.Add(new SelectListItem { Text = "Select Anaesthesia Type", Value = "0" });
            //model.AnathesiaList.Add(new SelectListItem { Text = "Anaesthesia", Value = "0" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Sedation", Value = "Sedation" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Local", Value = "Local" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Minor", Value = "Minor" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Intermidiate", Value = "Intermidiate" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Major 1", Value = "Major 1" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Major 2", Value = "Major 2" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Major Plus", Value = "Major Plus" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Complex Major", Value = "Complex Major" });



            //model.TheatreList.Add(new SelectListItem { Text = "Theathre", Value = "0" });
            model.TheatreList.Add(new SelectListItem { Text = "Minor", Value = "Minor" });
            model.TheatreList.Add(new SelectListItem { Text = "Intermidiate", Value = "Intermidiate" });
            model.TheatreList.Add(new SelectListItem { Text = "Major 1", Value = "Major 1" });
            model.TheatreList.Add(new SelectListItem { Text = "Major 2", Value = "Major 2" });
            model.TheatreList.Add(new SelectListItem { Text = "Major Plus", Value = "Major Plus" });
            model.TheatreList.Add(new SelectListItem { Text = "Complex Major", Value = "Complex Major" });



            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SurgicalInfo model)
        {

            Regex regex = new Regex(@"^[0-9]*$");
            Match match = regex.Match(model.hospitalNo);
            if (match.Success)
            {
                var values = GetPatientDetails(model.hospitalNo);

            
            model.hospitalNo = values.hospitalNo;
            model.PatientName = values.PatientName;
            model.Gender = values.Gender;
            model.Age = values.Age;



            model.AddmisionDate = DateTime.Today.ToShortDateString();
            model.ProcedureDate = DateTime.Today.ToShortDateString();

            //model.Doctors = GetSelectListItems();
            //model.DiagnosisCount = GetDiagnosisListItems();

            model.Doctors = GetDoctorsList();
            model.DiagnosisCount = GetDiagnosisList();


            //model.Procedures = GetProcedureListItems();
            //model.Beds = GetBedCategoryListItems();
            //model.surgeryClasses = GetSurgeryClassList();
            //model.investigations = GetLabInvestigationsItems();


            model.Procedures = GetProcedures();
            model.Beds = GetBeds();
            model.surgeryClasses = GetSurgeryClasses();
            model.investigations = GetInvestigations();

                model.GenderList.Add(new SelectListItem { Text = "Male", Value = "Male" });
                model.GenderList.Add(new SelectListItem { Text = "Female", Value = "Female" });

                model.AnathesiaList.Add(new SelectListItem { Text = "Anaesthesia", Value = "0" });
                model.AnathesiaList.Add(new SelectListItem { Text = "Sedation", Value = "Sedation" });
                model.AnathesiaList.Add(new SelectListItem { Text = "Local", Value = "Local" });
                model.AnathesiaList.Add(new SelectListItem { Text = "Minor", Value = "Minor" });
                model.AnathesiaList.Add(new SelectListItem { Text = "Intermidiate", Value = "Intermidiate" });
                model.AnathesiaList.Add(new SelectListItem { Text = "Major 1", Value = "Major 1" });
                model.AnathesiaList.Add(new SelectListItem { Text = "Major 2", Value = "Major 2" });
                model.AnathesiaList.Add(new SelectListItem { Text = "Major Plus", Value = "Major Plus" });
                model.AnathesiaList.Add(new SelectListItem { Text = "Complex Major", Value = "Complex Major" });



                //model.TheatreList.Add(new SelectListItem { Text = "Theathre", Value = "0" });
                model.TheatreList.Add(new SelectListItem { Text = "Minor", Value = "Minor" });
                model.TheatreList.Add(new SelectListItem { Text = "Intermidiate", Value = "Intermidiate" });
                model.TheatreList.Add(new SelectListItem { Text = "Major 1", Value = "Major 1" });
                model.TheatreList.Add(new SelectListItem { Text = "Major 2", Value = "Major 2" });
                model.TheatreList.Add(new SelectListItem { Text = "Major Plus", Value = "Major Plus" });
                model.TheatreList.Add(new SelectListItem { Text = "Complex Major", Value = "Complex Major" });
            }
            else
            {
                TempData["error"] = "Invalid Value: This is not an Hospital Number";
                return Redirect("Home/Index");
            }


            return View(model);

        }

        [HttpPost]
        public ActionResult PostingResult(SurgicalInfo model)
        {

            if (model.Doctor != 0 && model.Gender!=null)
            {
                try
                {
                    using (IDbConnection db = new SqlConnection(constr))
                    {
                        string insertQuery = @"INSERT INTO [dbo].[SurgicalOperationBooking]([RegistrationNo],[PatientName],[Gender],
                                    [Age], [ConsultantID], [Diagnosis],[AdmissionDate],[ProcedureDate],[ProcedureId], 
                                    [CoexistingMedicalCondition],[CurrentMedications],[SepecialRequrement],
                                    [AllotedTime],[BedCategoryId],[BedCost],[BedDays],[SugeryId],[SurgeryCost],
                                    [AnthesiaCategory],[AnthersiaCost],[TheretherCategory],[ThearterCost],[DateSubmitted]
                                     )VALUES (@hospitalNo,@PatientName, @Gender,
                                    @Age, @Doctor, @Diagnosistext,@AddmisionDate,@ProcedureDate,@Procedure, 
                                    @CoexistingMedConditions,@CurrentMedication,@SpecialRequirement,
                                    @AllottedTime,@BedID,@BedCost,@Beddays,@surgeryclassID,@surgeryCost,
                                    @AnathesiaListId,@AnathesiaCost,@TheatreListId,@TheatreCost, @DateSubmitted)";

                        SurgicalInfo sur = new SurgicalInfo();
                        sur.hospitalNo = model.hospitalNo;
                        sur.PatientName = model.PatientName;
                        sur.Gender = model.Gender;
                        sur.Age = model.Age;
                        sur.Doctor = model.Doctor;
                        sur.Diagnosistext = model.Diagnosistext;
                        sur.AddmisionDate = model.AddmisionDate;
                        sur.ProcedureDate = model.ProcedureDate;
                        sur.Procedure = model.Procedure;
                        sur.CoexistingMedConditions = model.CoexistingMedConditions;
                        sur.CurrentMedication = model.CurrentMedication;
                        sur.SpecialRequirement = model.SpecialRequirement;
                        sur.AllottedTime = model.AllottedTime;
                        sur.BedID = model.BedID;
                        sur.BedCost = model.BedCost;
                        sur.Beddays = model.Beddays;
                        sur.surgeryclassID = model.surgeryclassID;
                        sur.surgeryCost = model.surgeryCost;
                        sur.AnathesiaListId = model.AnathesiaListId;
                        sur.AnathesiaCost = model.AnathesiaCost;
                        sur.TheatreListId = model.TheatreListId;
                        sur.TheatreCost = model.TheatreCost;
                        sur.BedID = model.BedID;
                        sur.BedCost = model.BedCost;
                        sur.DateSubmitted = DateTime.Now;
                        var result = db.Execute(insertQuery, sur);
                        Session["sucess"] = "Values sucessfully submitted";
                    }
                }
                catch(Exception ex)
                {
                    if (ex.Message == "A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: Named Pipes Provider, error: 40 - Could not open a connection to SQL Server)")
                    {
                        TempData["error2"] = "Please check your internet Connection";
                    }
                    else
                    { TempData["error2"] = string.Format("An Error has occured:{0}", ex.Message); }
                    return RedirectToAction("Index");
                }

            }
            else
            {

            }

            var values = GetPatientDetails(model.hospitalNo);
            model.hospitalNo = values.hospitalNo;
            model.PatientName = values.PatientName;
            model.Gender = values.Gender;
            model.Age = values.Age;



            model.AddmisionDate = DateTime.Today.ToShortDateString();
            model.ProcedureDate = DateTime.Today.ToShortDateString();

            //model.Doctors = GetSelectListItems();
            //model.DiagnosisCount = GetDiagnosisListItems();

            model.Doctors = GetDoctorsList();
            model.DiagnosisCount = GetDiagnosisList();


            //model.Procedures = GetProcedureListItems();
            //model.Beds = GetBedCategoryListItems();
            //model.surgeryClasses = GetSurgeryClassList();
            //model.investigations = GetLabInvestigationsItems();


            model.Procedures = GetProcedures();
            model.Beds = GetBeds();
            model.surgeryClasses = GetSurgeryClasses();
            model.investigations = GetInvestigations();


            model.AnathesiaList.Add(new SelectListItem { Text = "Anaesthesia", Value = "0" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Sedation", Value = "Sedation" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Local", Value = "Local" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Minor", Value = "Minor" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Intermidiate", Value = "Intermidiate" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Major 1", Value = "Major 1" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Major 2", Value = "Major 2" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Major Plus", Value = "Major Plus" });
            model.AnathesiaList.Add(new SelectListItem { Text = "Complex Major",  Value = "Complex Major" });
            


            //model.TheatreList.Add(new SelectListItem { Text = "Theathre", Value = "0" });
            model.TheatreList.Add(new SelectListItem { Text = "Minor", Value = "Minor" });
            model.TheatreList.Add(new SelectListItem { Text = "Intermidiate", Value = "Intermidiate" });
            model.TheatreList.Add(new SelectListItem { Text = "Major 1", Value = "Major 1" });
            model.TheatreList.Add(new SelectListItem { Text = "Major 2", Value = "Major 2" });
            model.TheatreList.Add(new SelectListItem { Text = "Major Plus", Value = "Major Plus" });
            model.TheatreList.Add(new SelectListItem { Text = "Complex Major", Value = "Complex Major" });

            Session["hosNo"] = model.hospitalNo;

            return RedirectToAction("InvestigationsForms");

        }

        [HttpGet]
        public ActionResult GetAllListCharge()
        {
            

            string doctorsList = JsonConvert.SerializeObject(GetSelectListItems());
            string diagnosis = JsonConvert.SerializeObject(GetDiagnosisListItems());

            string Procedures = JsonConvert.SerializeObject(GetProcedureListItems());
            string Beds = JsonConvert.SerializeObject(GetBedCategoryListItems());
            string surgeryClasses = JsonConvert.SerializeObject(GetSurgeryClassList());
            string investigations = JsonConvert.SerializeObject(GetLabInvestigationsItems());

            System.IO.File.WriteAllText(Server.MapPath("~/JsonFiles/DoctorsList.json"), doctorsList);
            System.IO.File.WriteAllText(Server.MapPath("~/JsonFiles/diagnosis.json"), diagnosis);

            System.IO.File.WriteAllText(Server.MapPath("~/JsonFiles/Procedures.json"), Procedures);
            System.IO.File.WriteAllText(Server.MapPath("~/JsonFiles/Beds.json"), Beds);
            System.IO.File.WriteAllText(Server.MapPath("~/JsonFiles/surgeryClasses.json"), surgeryClasses);
            System.IO.File.WriteAllText(Server.MapPath("~/JsonFiles/investigations.json"), investigations);
            return View();
        }


        [HttpPost]
        public ActionResult GetPatientInfo(SurgicalInfo model)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            Match match = regex.Match(model.hospitalNo);
            if (match.Success)
            {
                var values = GetPatientDetails(model.hospitalNo);
                model.hospitalNo = values.hospitalNo;
                model.PatientName = values.PatientName;
                model.Gender = values.Gender;
                model.Age = values.Age;
                ViewBag.data = model;
                return Redirect("Home/Index");
            }
            else
            {
                TempData["error"] = "Invalid Value: This is not an Hospital Number";
                return Redirect("Home/Index");
            }
            //return Redirect("Home/Index");
                //RedirectToAction("Index","Home");
        }
        public SurgicalInfo GetPatientDetails(string PatientId)
        {
            SurgicalInfo ObjMTDMaster = new SurgicalInfo();
            try
            {
                var objDetails = SqlMapper.QueryMultiple(con, "PatientInfo", new { HospitalNum = PatientId }, null, null, commandType: CommandType.StoredProcedure);

                ObjMTDMaster = objDetails.Read<SurgicalInfo>().SingleOrDefault();
                con.Close();
            }
            catch(Exception ex)
            {
                if (ex.Message == "A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: Named Pipes Provider, error: 40 - Could not open a connection to SQL Server)")
                {
                    TempData["error2"] = "Please check your internet Connection";
                }
                else
                { TempData["error2"] = string.Format("An Error has occured:{0}", ex.Message); }
                //return RedirectToAction("Index");
            }
            return ObjMTDMaster;
        }

        private List<SelectListItem> GetDiagnosisListItems()
        {
            SurgicalInfo ObjMTDMaster = new SurgicalInfo();
            var objDetails = SqlMapper.QueryMultiple(con, "FormDiagnosis", commandType: CommandType.StoredProcedure);
            ObjMTDMaster.DiagnosisList = objDetails.Read<DiagnosisList>().ToList();
            //var json = JsonConvert.SerializeObject(ObjMTDMaster.DiagnosisList);
            //System.IO.File.WriteAllText(@"C:\Users\festu\Desktop\HappinessForm\HappinessForm\Content\Diagnosis.json", json);

            con.Close();
            var selectList = new List<SelectListItem>();
            foreach (var element in ObjMTDMaster.DiagnosisList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.ICDId.ToString(),
                    Text = element.Diagnosis
                });
            }

            return selectList;
        }

        private List<SelectListItem> GetBedCategoryListItems()
        {
            SurgicalInfo ObjMTDMaster = new SurgicalInfo();
            var objDetails = SqlMapper.QueryMultiple(con, "Bedcategory", commandType: CommandType.StoredProcedure);
            ObjMTDMaster.BedList = objDetails.Read<BedCategory>().ToList();
            con.Close();
            var selectList = new List<SelectListItem>();
            foreach (var element in ObjMTDMaster.BedList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.ServiceId.ToString(),
                    Text = element.ServiceName
                });
            }

            return selectList;
        }


        private List<SelectListItem> GetProcedureListItems()
        {
            SurgicalInfo ObjMTDMaster = new SurgicalInfo();
            var objDetails = SqlMapper.QueryMultiple(con, "ProcedureList", commandType: CommandType.StoredProcedure);
            ObjMTDMaster.ProcedureList = objDetails.Read<ProcedureList>().ToList();
            con.Close();
            var selectList = new List<SelectListItem>();
            foreach (var element in ObjMTDMaster.ProcedureList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.ServiceId.ToString(),
                    Text = element.ServiceName
                });
            }

            return selectList;
        }

        public List<SelectListItem> GetDoctorsList()
        {
            using (StreamReader r = new StreamReader(Server.MapPath("~/JsonFiles/DoctorsList.json")))
            {
                using (JsonTextReader reader = new JsonTextReader(r))
                {
                    reader.SupportMultipleContent = true;
                    JsonSerializer serializer = new JsonSerializer();

                    // read the json from a stream
                    // json size doesn't matter because only a small piece is read at a time from the HTTP request
                    List<SelectListItem> result = serializer.Deserialize<List<SelectListItem>>(reader);
                    return result;
                }
            }
           
        }

        public List<SelectListItem> GetDiagnosisList()
        {
            //using (StreamReader r = new StreamReader(Server.MapPath("~/JsonFiles/diagnosis.json")))
            //{
            //    string json = r.ReadToEnd();
            //    List<SelectListItem> items = JsonConvert.DeserializeObject<List<SelectListItem>>(json);
            //    return items;
            //}

            using (StreamReader sr = new StreamReader(Server.MapPath("~/JsonFiles/diagnosis.json")))
            {
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    reader.SupportMultipleContent = true;
                    JsonSerializer serializer = new JsonSerializer();

                    // read the json from a stream
                    // json size doesn't matter because only a small piece is read at a time from the HTTP request
                    List<SelectListItem> result = serializer.Deserialize<List<SelectListItem>>(reader);
                    return result;
                }
            }


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
        public List<SelectListItem> GetProcedures()
        {
            using (StreamReader r = new StreamReader(Server.MapPath("~/JsonFiles/Procedures.json")))
            {
                string json = r.ReadToEnd();
                List<SelectListItem> items = JsonConvert.DeserializeObject<List<SelectListItem>>(json);
                return items;
            }

        }

        public List<SelectListItem> GetInvestigations()
        {
            using (StreamReader r = new StreamReader(Server.MapPath("~/JsonFiles/investigations.json")))
            {
                string json = r.ReadToEnd();
                List<SelectListItem> items = JsonConvert.DeserializeObject<List<SelectListItem>>(json);
                return items;
            }

        }

        public List<SelectListItem> GetSurgeryClasses()
        {
            using (StreamReader r = new StreamReader(Server.MapPath("~/JsonFiles/surgeryClasses.json")))
            {
                string json = r.ReadToEnd();
                List<SelectListItem> items = JsonConvert.DeserializeObject<List<SelectListItem>>(json);
                return items;
            }

        }

        private List<SelectListItem> GetSelectListItems()
        {
            SurgicalInfo ObjMTDMaster = new SurgicalInfo();
            var objDetails = SqlMapper.QueryMultiple(con, "DoctorsList", commandType: CommandType.StoredProcedure);
            ObjMTDMaster.DoctorList = objDetails.Read<DoctorsList>().ToList();
            con.Close();
            var selectList = new List<SelectListItem>();
            foreach (var element in ObjMTDMaster.DoctorList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.DoctorName
                });
            }

            return selectList;
        }


        private List<SelectListItem> GetSurgeryClassList()
        {
            SurgicalInfo ObjMTDMaster = new SurgicalInfo();
            var objDetails = SqlMapper.QueryMultiple(con, "SurgeryClass", commandType: CommandType.StoredProcedure);
            ObjMTDMaster.surgeryList = objDetails.Read<SurgeryCategory>().ToList();
            con.Close();
            var selectList = new List<SelectListItem>();
            foreach (var element in ObjMTDMaster.surgeryList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }

            return selectList;
        }



        private List<SelectListItem> GetLabInvestigationsItems()
        {
            SurgicalInfo ObjMTDMaster = new SurgicalInfo();
            var objDetails = SqlMapper.QueryMultiple(con, "LabInvestigation", commandType: CommandType.StoredProcedure);
            ObjMTDMaster.LabInvestigations = objDetails.Read<LabInvestigations>().ToList();
            con.Close();
            var selectList = new List<SelectListItem>();
            foreach (var element in ObjMTDMaster.LabInvestigations)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.ServiceId.ToString(),
                    Text = element.ServiceName
                });
            }

            return selectList;
        }
        private List<SelectListItem> GetLabInvestigationsItemsById(int labId)
        {
            SurgicalInfo ObjMTDMaster = new SurgicalInfo();
            var objDetails = SqlMapper.QueryMultiple(con, "LabInvestigationById", commandType: CommandType.StoredProcedure);
            ObjMTDMaster.LabInvestigations = objDetails.Read<LabInvestigations>().ToList();
            con.Close();
            var selectList = new List<SelectListItem>();
            foreach (var element in ObjMTDMaster.LabInvestigations)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.ServiceId.ToString(),
                    Text = element.ServiceName
                });
            }

            return selectList;
        }

        public List<Investigations> LabInvest(DateTime date,string RegNo)
          {
            //var objMTDDetails = SqlMapper.QueryMultiple(con, "RunningPayorMixMTDCountVsRevenueOPDPost", new { facilityId = facilities, endTime = DateTime.Parse(End) }, null, null, commandType: CommandType.StoredProcedure);
            var objDetails = SqlMapper.QueryMultiple(con, "labInvestperPatient", new { @RegNo = RegNo, @date = date }, null, null, commandType: CommandType.StoredProcedure);

            Investigations k = new Investigations();
            var t = objDetails.Read<Investigations>().ToList();
            return t;
        }

        public int ProcedureSectonID (DateTime date, string RegNo)
        {
            var objDetails = SqlMapper.QueryMultiple(con, "GetSurgerybokingID", new { @RegNo = RegNo, @date = date }, null, null, commandType: CommandType.StoredProcedure);
            var id = objDetails.Read<int>().ToList().LastOrDefault();
            return id;
        }

        [HttpGet]
        public ActionResult InvestigationsForms()
        {
            SurgicalInfo model = new SurgicalInfo();

            if (Session["hosNo"]!=null)
            {
              
                model.investigations = GetLabInvestigationsItems();
                var RegNo = Session["hosNo"].ToString();
                var getPatList = LabInvest(DateTime.Today, RegNo);

                model.ListofLabTest = getPatList;
              

            }
            else
            {
                model.investigations = GetLabInvestigationsItems();
                Session["error"] = "This Session has expired please click the back button";
                return RedirectToAction("Index");
            }
            return View(model);

        }


        public ActionResult Delete (int Id)
        {
            using (IDbConnection db = new SqlConnection(constr))
            {
                string insertQuery = string.Format(@"Update Forminvestigations set Active=0 where Id={0}",Id);
                var result = db.Execute(insertQuery);
                Session["Deleted"] = "Sucessfully Deleted";
            }
            return RedirectToAction("InvestigationsForms");
        }
        [HttpPost]
        public ActionResult InvestigationsForms(SurgicalInfo model)
        {
            if (Session["hosNo"] != null)
            {
                var Regno = Session["hosNo"].ToString();
                var id = ProcedureSectonID(DateTime.Today, Regno);
                using (IDbConnection db = new SqlConnection(constr))
            {
                string insertQuery = @"INSERT INTO [dbo].[Forminvestigations]([Unit], [Cost], [InvestigationId], [investigationDate], [RegistrationNo],[Active],[SurgeryBookId])VALUES (@Unit, @Cost, @InvestigationId, @investigationDate, @RegistrationNo,@Active,@SurgeryBookId)";

                Investigations inv = new Investigations();
                inv.InvestigationId = model.investID;
                inv.InvestigationDate = DateTime.Today;
                inv.Unit = model.Labunit;
                inv.Cost = decimal.Parse(model.LabCost)* model.Labunit;
                inv.RegistrationNo = Regno;
                inv.Active = true;
                inv.SurgeryBookId = id;
                var result = db.Execute(insertQuery, inv);
            }
            var getPatList = LabInvest(DateTime.Today, Regno);
            model.ListofLabTest = getPatList;
            model.investigations = GetLabInvestigationsItems();
            }
            else
            {
                model.investigations = GetLabInvestigationsItems();
                Session["error"] = "This Session has expired please click the back button";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult result()
        {
            return View();
        }
    }
}