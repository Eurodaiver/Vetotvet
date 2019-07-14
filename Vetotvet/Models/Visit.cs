using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vetotvet.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Client Client { get; set; }
        public Pet Pet { get; set; }
        public string Reason { get; set; }
        public string Treatment { get; set; }
        public VisitType VisitType { get; set; }
        public string Recommendation { get; set; }
        public float Summ { get; set; }
    }
}
