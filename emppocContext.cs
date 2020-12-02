using System;
using System.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ef5_core31_poc
{
    public partial class emppocContext : DbContext
    {
        public emppocContext()
        {
        }

        public emppocContext(DbContextOptions<emppocContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                var configRoot = (new ConfigurationBuilder()).AddUserSecrets<Program>().Build();
                var connectionString = configRoot["ConnectionStrings.EmployeesPoc"];
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(n =>{
                n.HasKey(c => c.EmployeeID);
            
                n.Property(c => c.EmployeeNumber)
                    .HasMaxLength(60)
                    .IsRequired();
                n.Property(c => c.EmployeeUpn)
                    .HasMaxLength(200);
                n.Property(c => c.EmployeeDisplayName)
                    .HasMaxLength(200);
            });
        }
    }
}
