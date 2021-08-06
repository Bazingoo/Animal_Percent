using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Val_Bogus
{
    public class EFContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;" +
                "Port=5432;" +
                "Database=dbanimals;" +
                "Username=postgres;" +
                "Password=1234567");
        }
    }
}
