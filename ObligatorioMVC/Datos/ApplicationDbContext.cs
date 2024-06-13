using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ObligatorioMVC.Models;

namespace ObligatorioMVC.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> 
            options) : base (options)
        {

        }

        //Modelos a crear
        public DbSet<Ejercicio> Ejercicio { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Maquina> Maquina { get; set; }
        public DbSet<ResponsableLocal> ResponsableLocal { get; set; }
        public DbSet<Rutina> Rutina { get; set; }
        public DbSet<RutinaEjercicio> rutinaEjercicios { get; set; }
        public DbSet<Socio> Socio { get; set; }
        public DbSet<SocioRutina> SocioRutina { get; set; }
        public DbSet<TipoMaquina> TipoMaquina { get; set; }
        public DbSet<TipoRutina> TipoRutina { get; set; }
        public DbSet<TipoSocio> TipoSocio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(up => up.Ejercicio)
                .WithMany(up => up.rutinaEjercicios)
                .HasForeignKey(up => up.IdEjercicio);

            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(up => up.Rutina)
                .WithMany(up => up.rutinaEjercicios)
                .HasForeignKey(up => up.IdRutina);

            modelBuilder.Entity<SocioRutina>()
                .HasOne(up => up.Socio)
                .WithMany(up => up.socioRutinas)
                .HasForeignKey(up => up.idSocio);

            modelBuilder.Entity<SocioRutina>()
                .HasOne(up => up.Rutina)
                .WithMany(up => up.socioRutinas)
                .HasForeignKey(up => up.idRutina);
        }
    }


}
