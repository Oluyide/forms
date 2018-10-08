using System;
using System.Collections.Generic;

namespace FormCore.Models
{
    public partial class Happiness
    {
        public int Id { get; set; }
        public System.DateTime DataCollectionDate { get; set; }
        public Nullable<System.TimeSpan> TimeIn { get; set; }
        public Nullable<System.TimeSpan> TimeOut { get; set; }
        public string Company { get; set; }
        public string EncounterNo { get; set; }
        public Nullable<int> PlanCategoryId { get; set; }
        public Nullable<int> ClinicId { get; set; }
        public string YourbestStaff { get; set; }
        public string FrontDeskName { get; set; }
        public string FrontDeskRating { get; set; }
        public string VitalSigns { get; set; }
        public string VitalSignsRating { get; set; }
        public string Consultations { get; set; }
        public string ConsultationsRating { get; set; }
        public string Phamarcy { get; set; }
        public string PharmarcyRating { get; set; }
        public string Lab { get; set; }
        public string LabRating { get; set; }
        public string XRays { get; set; }
        public string XRaysRating { get; set; }
        public string ECG { get; set; }
        public string ECGRating { get; set; }
        public string ScanUltrasound { get; set; }
        public string ScanRating { get; set; }
        public string Echocardiograpy { get; set; }
        public string echoRating { get; set; }
        public string Billing { get; set; }
        public string BillingRating { get; set; }
        public string CTScan { get; set; }
        public string CTScanRating { get; set; }
        public string MRI { get; set; }
        public string ERTreatmentRoom { get; set; }
        public string ERRating { get; set; }
        public string Others { get; set; }
        public string OthersRating { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public System.DateTime DateOfVisit { get; set; }
    }
}
