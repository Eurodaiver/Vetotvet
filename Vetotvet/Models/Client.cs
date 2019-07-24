using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vetotvet.Models
{
    [DisplayName("Клиент")]
    public class Client
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [InverseProperty("Owner")]
        public ICollection<Pet> Pets { get; set; }
        public ICollection<Visit> Visits { get; set; }

 
    }
}
