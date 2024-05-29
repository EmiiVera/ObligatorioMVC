using Microsoft.EntityFrameworkCore;

namespace ObligatorioMVC.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> 
            options) : base (options) { }
    }
}
