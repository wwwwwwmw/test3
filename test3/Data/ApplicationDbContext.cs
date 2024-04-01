using Microsoft.EntityFrameworkCore;
using test3.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using mn.Models;

namespace mn.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}