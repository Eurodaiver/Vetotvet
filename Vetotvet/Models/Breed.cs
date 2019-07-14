using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vetotvet.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public int? KindOfAnimalId { get; set; }
        public KindOfAnimal KindOfAnimal { get; set; }
        public string Name { get; set; }
    }
}
