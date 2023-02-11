using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperManagement.Context
{
    public class DevelopersContext:DbContext
    {
        public DevelopersContext() { }
        public DevelopersContext(DbContextOptions<DevelopersContext> dbContextOptions) :base(dbContextOptions){ }
        public DbSet<Developers> Developers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // lets seed some data
            modelBuilder.Entity<Developers>(opt => opt.HasData(
                new Developers { DeveloperId = 1, Name = "Ali", Age = 27, JobTitle = "Jr. Developer 1" },
                new Developers { DeveloperId = 2, Name = "Osman", Age = 29, JobTitle = "Jr. Developer 2" },
                new Developers { DeveloperId = 3, Name = "Subhan", Age = 37, JobTitle = "Sr. Developer 1" }
                ));
            // lets reflect changes to db by migrations
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
