using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vetotvet.Models;

namespace Vetotvet.Data
{
    public class VetotvetDbContext : DbContext
    {
        public VetotvetDbContext(DbContextOptions<VetotvetDbContext> options)
             : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<KindOfAnimal> KindOfAnimals { get; set; }

    }
}
