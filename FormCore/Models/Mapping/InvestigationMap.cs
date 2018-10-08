using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormCore.Models.Mapping
{
    public class InvestigationMap : EntityTypeConfiguration<Investigations>
    {
        public InvestigationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
           

           
            // Table & Column Mappings
            this.ToTable("Investigations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.InvestigationId).HasColumnName("InvestigationId");
            this.Property(t => t.InvestigationDate).HasColumnName("InvestigationDate");
            this.Property(t => t.RegistrationNo).HasColumnName("RegistrationNo");
        }
    }
}
