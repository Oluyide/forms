using FormCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HappinessForm.Models
{
    public class PatientResponseModel
    {
        public PatientResponseModel()
        {
           
            PlanList = new List<SelectListItem>();
            ClinicList = new List<SelectListItem>();
            FrontDeskRate = new List<SelectListItem>();
            VitalSignsRate = new List<SelectListItem>();
            ConsultationsRate = new List<SelectListItem>();
            PharmacyRate = new List<SelectListItem>();
            LabRate = new List<SelectListItem>();
            xRaysRate = new List<SelectListItem>();
            ECGRate = new List<SelectListItem>();
            xRaysRate = new List<SelectListItem>();
            ScanRate = new List<SelectListItem>();
            xRaysRate = new List<SelectListItem>();
            EChocaardiograhyRate = new List<SelectListItem>();
            BillingRate = new List<SelectListItem>();
            EChocaardiograhyRate = new List<SelectListItem>();
            CTScanRates = new List<SelectListItem>();

            MRIRates = new List<SelectListItem>();

            CTScanRates = new List<SelectListItem>();
            ERTreamentRates = new List<SelectListItem>();
            OthersRate = new List<SelectListItem>();

            //Specialist = new IEnumerable<Specialization>();
        }

        [DisplayName("Plan Categotry")]
        public List<SelectListItem> PlanList{get; set;}

        [DisplayName("Clinic")]
        public List<SelectListItem> ClinicList { get; set; }

        public List<SelectListItem> FrontDeskRate { get; set; }
        public List<SelectListItem> VitalSignsRate { get; set; }
        public List<SelectListItem> ConsultationsRate{ get; set; }
        public List<SelectListItem> PharmacyRate { get; set; }
        public List<SelectListItem> LabRate { get; set; }
        public List<SelectListItem> xRaysRate { get; set; }
        public List<SelectListItem> ECGRate{ get; set; }
        public List<SelectListItem> ScanRate { get; set; }

        public List<SelectListItem> EChocaardiograhyRate { get; set; }

        public List<SelectListItem> BillingRate { get; set; }

        public List<SelectListItem> CTScanRates { get; set; }

        public List<SelectListItem> MRIRates { get; set; }

        public List<SelectListItem> ERTreamentRates { get; set; }

        public List<SelectListItem>  OthersRate { get; set; }

        //public List<SelectListItem> Specialist { get; set; }
        public IEnumerable<Specialization> Specialists { get; set; }
        public int SpecialistId { get; set; }
        //public List<CheckBoxListItem> PlanCategory { get; set; }
        //public List<CheckBoxListItem> ClinicName { get; set; }
        //public List<CheckBoxListItem> ClinicName { get; set; }
        //public List<CheckBoxListItem> ClinicName { get; set; }
        //public List<CheckBoxListItem> ClinicName { get; set; }

        public int Id { get; set; }

       
        public System.DateTime DataCollectionDate { get; set; }
        [Display(Name = "TimeIn")]
        public Nullable<System.TimeSpan> TimeIn { get; set; }
        [Display(Name = "TimeOut")]
        public Nullable<System.TimeSpan> TimeOut { get; set; }
        [Display(Name = "Company")]
        public string Company { get; set; }
        [Display(Name = "Encounter No")]
        public string EncounterNo { get; set; }
        
        public Nullable<int> PlanCategoryId { get; set; }
       
        public Nullable<int> ClinicId { get; set; }
        [Display(Name = "Please Indicate the name of one member of staff that best attend to you")]
        public string YourbestStaff { get; set; }
        
        [Display(Name="Front Desk officer Name")]
        public string FrontDeskName { get; set; }
        [Display(Name = "Date")]
        public string FrontDeskRating { get; set; }
        [Display(Name = "Vital Signs Desk")]
        public string VitalSigns { get; set; }
        [Display(Name = "Date")]
        public string VitalSignsRating { get; set; }
        [Display(Name = "Consultations")]
        public string Consultations { get; set; }
       
        public string ConsultationsRating { get; set; }
        [Display(Name = "Phamarcy")]
        public string Phamarcy { get; set; }
       
        public string PharmarcyRating { get; set; }
        [Display(Name = "Lab")]
        public string Lab { get; set; }
   
        public string LabRating { get; set; }
        [Display(Name = "X-rays")]
        public string XRays { get; set; }
        [Display(Name = "")]
        public string XRaysRating { get; set; }
        [Display(Name = "ECG")]

        public string ECG { get; set; }
        [Display(Name = "Date")]
        public string ECGRating { get; set; }
        [Display(Name = "Scan(Ultrasound)")]
        public string ScanUltrasound { get; set; }
        [Display(Name = "Date")]
        public string ScanRating { get; set; }
        [Display(Name = "Echocardiography")]
        public string Echocardiograpy { get; set; }
       
        public string echoRating { get; set; }
        [Display(Name = "Billing")]
        public string Billing { get; set; }
     
        public string BillingRating { get; set; }
        [Display(Name = "CT Scan")]
        public string CTScan { get; set; }
        [Display(Name = "Date")]
        public string CTScanRating { get; set; }
        [Display(Name = "MRI")]

        public string MRI { get; set; }

        public string MRIRating { get; set; }
        [Display(Name = "ER/Treatment room")]
        public string ERTreatmentRoom { get; set; }

        public string ERRating { get; set; }

        [Display(Name = "Others")]
        public string Others { get; set; }
        [Display(Name = "Date")]
        public string OthersRating { get; set; }

        [Display(Name = "Comment/Suggestion")]
        public string Comment { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Date")]
        public System.DateTime DateOfVisit { get; set; }

        
    }
}
