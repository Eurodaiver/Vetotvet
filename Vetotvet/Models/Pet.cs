using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vetotvet.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? KindOfAnimalId { get; set; }
        public KindOfAnimal KindOfAnimal { get; set; }
        public int? BreedId { get; set; }
        public Breed Breed { get; set; }
        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Chip { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
