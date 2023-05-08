using Microsoft.EntityFrameworkCore;

namespace Miquella_BackEnd.DataAccesLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JUR5FT4;database=MiquellaAPI; integrated security=true; TrustServerCertificate=True");
        }
        public DbSet<New> News { get; set; }
    }
}
