using Microsoft.EntityFrameworkCore;

namespace crud_EF.Models
{
    internal class CRUD_EFContext:DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CRUD;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
