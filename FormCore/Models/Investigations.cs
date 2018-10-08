using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormCore.Models
{
    public partial class Investigations
    {
        public int Id { get; set; }

        public int Unit { get; set; }

        public decimal Cost { get; set; }
        public int InvestigationId { get; set; }
        public DateTime InvestigationDate { get; set; }
        public string RegistrationNo { get; set; }
        public string InvestigationName { get;  set;}
        public bool Active { get; set; }
        public int SurgeryBookId { get; set; }
    }


    public class InvsestList
   {
    public List<Investigations> PatientTests { get; set; }
     }
}
