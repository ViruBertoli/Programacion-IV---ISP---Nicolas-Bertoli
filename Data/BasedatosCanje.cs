using Microsoft.EntityFrameworkCore;
using PlanCanjeWeb.Models;

namespace PlanCanjeWeb.Data
{
    public class BasedatosCanje : DbContext
    {
        public BasedatosCanje(DbContextOptions<BasedatosCanje> options)
            : base(options)
        {
        }

        public DbSet<Equipoafectado> Equipoafectados { get; set; }
    }
}
