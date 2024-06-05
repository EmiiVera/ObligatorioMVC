using Microsoft.EntityFrameworkCore;
using ObligatorioMVC.Models;

namespace ObligatorioMVC.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> 
            options) : base (options) { }
    }

    //Modelos a crear
    public DbSet<Ejercicio> Ejercicio { get; set; }
    public DbSet<Local> Local { get; set; }
    public DbSet<Maquina> Maquina { get; set; }
    public DbSet<ResponsableLocal> ResponsableLocal { get; set; }
    public DbSet<Rutina> Rutina { get; set; }
    public DbSet<Socio> Socio { get; set; }
    public DbSet<TipoMaquina> TipoMaquina { get; set; }
    public DbSet<Usuario> Usuario { get; set; }

}
