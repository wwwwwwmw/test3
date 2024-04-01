using Microsoft.EntityFrameworkCore;
using mn.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace mn.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Danhsach> Danhsaches { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Thanh Viet", PhoneNumber = 0123456789, UniversityId = 1 }
            );
            modelBuilder.Entity<Danhsach>().HasData(
            new Danhsach { Id = 1, University = "Dai hoc bach khoa ha noi" }
            );
        }
    }
}