using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public ICollection<Pet> Pets { get; set; }
        public ICollection<Visit> Visits { get; set; }
        public Client()
        {
            Pets = new List<Pet>();
            Visits = new List<Visit>();
        }
    }
}
