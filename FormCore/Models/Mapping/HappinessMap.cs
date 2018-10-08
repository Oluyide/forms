using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FormCore.Models.Mapping
{
    public class HappinessMap : EntityTypeConfiguration<Happiness>
    {
        public HappinessMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Company)
                .HasMaxLength(50);

            this.Property(t => t.EncounterNo)
                .HasMaxLength(50);

            this.Property(t => t.FrontDeskName)
                .HasMaxLength(50);

            this.Property(t => t.FrontDeskRating)
                .HasMaxLength(50);

            this.Property(t => t.VitalSigns)
                .HasMaxLength(50);

            this.Property(t => t.VitalSignsRating)
                .HasMaxLength(50);

            this.Property(t => t.Consultations)
                .HasMaxLength(50);

            this.Property(t => t.ConsultationsRating)
                .HasMaxLength(50);

            this.Property(t => t.Phamarcy)
                .HasMaxLength(50);

            this.Property(t => t.PharmarcyRating)
                .HasMaxLength(50);

            this.Property(t => t.Lab)
                .HasMaxLength(50);

            this.Property(t => t.LabRating)
                .HasMaxLength(50);

            this.Property(t => t.XRays)
                .HasMaxLength(50);

            this.Property(t => t.XRaysRating)
                .HasMaxLength(50);

            this.Property(t => t.ECG)
                .HasMaxLength(50);

            this.Property(t => t.ECGRating)
                .HasMaxLength(50);

            this.Property(t => t.ScanUltrasound)
                .HasMaxLength(50);

            this.Property(t => t.ScanRating)
                .HasMaxLength(50);

            this.Property(t => t.Echocardiograpy)
                .HasMaxLength(50);

            this.Property(t => t.echoRating)
                .HasMaxLength(50);

            this.Property(t => t.Billing)
                .HasMaxLength(50);

            this.Property(t => t.BillingRating)
                .HasMaxLength(50);

            this.Property(t => t.CTScan)
                .HasMaxLength(50);

            this.Property(t => t.CTScanRating)
                .HasMaxLength(50);

            this.Property(t => t.MRI)
                .HasMaxLength(50);

            this.Property(t => t.ERTreatmentRoom)
                .HasMaxLength(50);

            this.Property(t => t.ERRating)
                .HasMaxLength(50);

            this.Property(t => t.Others)
                .HasMaxLength(50);

            this.Property(t => t.OthersRating)
                .HasMaxLength(50);

            this.Property(t => t.Comment)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Happiness");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DataCollectionDate).HasColumnName("DataCollectionDate");
            this.Property(t => t.TimeIn).HasColumnName("TimeIn");
            this.Property(t => t.TimeOut).HasColumnName("TimeOut");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.EncounterNo).HasColumnName("EncounterNo");
            this.Property(t => t.PlanCategoryId).HasColumnName("PlanCategoryId");
            this.Property(t => t.ClinicId).HasColumnName("ClinicId");
            this.Property(t => t.YourbestStaff).HasColumnName("YourbestStaff");
            this.Property(t => t.FrontDeskName).HasColumnName("FrontDeskName");
            this.Property(t => t.FrontDeskRating).HasColumnName("FrontDeskRating");
            this.Property(t => t.VitalSigns).HasColumnName("VitalSigns");
            this.Property(t => t.VitalSignsRating).HasColumnName("VitalSignsRating");
            this.Property(t => t.Consultations).HasColumnName("Consultations");
            this.Property(t => t.ConsultationsRating).HasColumnName("ConsultationsRating");
            this.Property(t => t.Phamarcy).HasColumnName("Phamarcy");
            this.Property(t => t.PharmarcyRating).HasColumnName("PharmarcyRating");
            this.Property(t => t.Lab).HasColumnName("Lab");
            this.Property(t => t.LabRating).HasColumnName("LabRating");
            this.Property(t => t.XRays).HasColumnName("XRays");
            this.Property(t => t.XRaysRating).HasColumnName("XRaysRating");
            this.Property(t => t.ECG).HasColumnName("ECG");
            this.Property(t => t.ECGRating).HasColumnName("ECGRating");
            this.Property(t => t.ScanUltrasound).HasColumnName("ScanUltrasound");
            this.Property(t => t.ScanRating).HasColumnName("ScanRating");
            this.Property(t => t.Echocardiograpy).HasColumnName("Echocardiograpy");
            this.Property(t => t.echoRating).HasColumnName("echoRating");
            this.Property(t => t.Billing).HasColumnName("Billing");
            this.Property(t => t.BillingRating).HasColumnName("BillingRating");
            this.Property(t => t.CTScan).HasColumnName("CTScan");
            this.Property(t => t.CTScanRating).HasColumnName("CTScanRating");
            this.Property(t => t.MRI).HasColumnName("MRI");
            this.Property(t => t.ERTreatmentRoom).HasColumnName("ERTreatmentRoom");
            this.Property(t => t.ERRating).HasColumnName("ERRating");
            this.Property(t => t.Others).HasColumnName("Others");
            this.Property(t => t.OthersRating).HasColumnName("OthersRating");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DateOfVisit).HasColumnName("DateOfVisit");
        }
    }
}
