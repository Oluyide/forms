using FormCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappinessForm.Models
{
    public class SurgicalInfo
    {
       
        public SurgicalInfo()
        {

            AnathesiaList = new List<SelectListItem>();
            TheatreList = new List<SelectListItem>();
            GenderList=new List<SelectListItem>();



        }
        public int Id { get; set; }

        [DisplayName("Patient Name")]

        public string PatientName { get; set; }
      
        [DisplayName("Hospital No")]
        //[RegularExpression(@"^\d$", ErrorMessage = "\nValue must an ")]
        public string hospitalNo { get; set; }
        public string FullName { get; set; }

        //[DisplayName("Gender")]
        //public List<SelectListItem> gender { get; set; }
        //public Nullable<int> genderId { get; set; }

        public string Gender { get; set; }
        public List<SelectListItem> GenderList { get; set; }
        [RegularExpression(@"^\d$", ErrorMessage = "\nValue must be an integer")]
        [DisplayName("Age")]
        public int Age { get; set; }
        public int Doctor { get; set; }
        public List<SelectListItem> Doctors { get; set; }
        public List<DoctorsList> DoctorList { get; set; }

        public int Diagnosis { get; set; }

        [RegularExpression("^[0-9]([.,][0-9]{1,3})?$", ErrorMessage = "\nValue must be in text")]
        public string Diagnosistext { get; set; }
        public List<SelectListItem> DiagnosisCount { get; set; }
        public List<DiagnosisList> DiagnosisList { get; set; }


        public int Procedure { get; set; }
        public List<SelectListItem> Procedures { get; set; }
        public List<ProcedureList> ProcedureList { get; set; }
        public string ProcedureText { get; set; }

        public int BedID { get; set; }
        public DateTime DateSubmitted { get; set; }
        public List<SelectListItem> Beds { get; set; }
        public List<BedCategory> BedList { get; set; }

        public int surgeryclassID { get; set; }
        public List<SelectListItem> surgeryClasses { get; set; }
        public List<SurgeryCategory> surgeryList { get; set; }


        public int investID { get; set; }

        public int MainId { get; set; }
        public string  investName { get; set; }
        public List<SelectListItem> investigations { get; set; }
        public List<LabInvestigations> LabInvestigations { get; set; }
        public bool Active { get; set; }

        [RegularExpression("^[0-9]([.,][0-9]{1,3})?$", ErrorMessage = "\nValue must be in two decimal places")]
        public string LabCost { get; set; }
        [RegularExpression(@" ^\d$", ErrorMessage = "\nValue must be  an integer")]
        public int Labunit { get; set; }
        [RegularExpression("^([A-Za-z]+( [-'A-Za-z]+)*){3,40}$", ErrorMessage = "\nValue must be in two decimal places")]
        public decimal surgeryCost { get; set; }
        [RegularExpression("^[0-9]([.,][0-9]{1,3})?$", ErrorMessage = "\nValue must be in two decimal places")]
        public decimal BedCost { get; set; }
        [RegularExpression("^[0-9]([.,][0-9]{1,3})?$", ErrorMessage = "\nValue must be in two decimal places")]
        public string Beddays { get; set; }
      
        public decimal Weight { get; set; }


        public string consultantIncharge { get; set; }
        public string PatientDiagnosis { get; set; }

        public string AddmisionDate { get; set; }
        public string ProcedureDate { get; set; }

        
        public string CoexistingMedConditions { get; set; }

        
        public string CurrentMedication { get; set; }
       
        public string SpecialRequirement{ get; set; }
        public string AllottedTime { get; set; }

        [DisplayName("Anathesia")]
        public List<SelectListItem> AnathesiaList { get; set; }

        public string AnathesiaListId { get; set; }
        [RegularExpression("^[0-9]([.,][0-9]{1,3})?$", ErrorMessage = "\nValue must be in two decimal places")]
        public string AnathesiaCost { get; set; }
        [DisplayName("Theathre")]
        public List<SelectListItem> TheatreList { get; set; }
        public string TheatreListId { get; set; }
        [RegularExpression("^[0-9]([.,][0-9]{1,3})?$", ErrorMessage = "\nValue must be in two decimal places")]
        public decimal TheatreCost { get; set; }

        public List<Investigations> ListofLabTest { get; set; }
        public List<SurgicalInfo> ListOfEntries { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    public class DoctorsList
    {
        public  int Id { get; set; }
        public string DoctorName { get; set; }
    }

    public class DiagnosisList
    {
        public int ICDId { get; set; }
        public string Diagnosis { get; set; }
    }


    public class ProcedureList
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
    public class BedCategory
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }

    public class SurgeryCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class LabInvestigations
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}