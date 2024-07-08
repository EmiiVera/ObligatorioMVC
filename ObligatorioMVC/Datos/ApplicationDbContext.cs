using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ObligatorioMVC.Models;

namespace ObligatorioMVC.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
            options) : base(options)
        {

        }

        //Modelos a crear
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<Local> Locales { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<RutinaEjercicio> RutinaEjercicios { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<SocioRutina> SocioRutinas { get; set; }
        public DbSet<TipoMaquina> TipoMaquinas { get; set; }
        public DbSet<TipoRutina> TipoRutinas { get; set; }
        public DbSet<TipoSocio> TipoSocios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuracion para relacion N a N
            //RutinaEjercicio
            modelBuilder.Entity<RutinaEjercicio>()
                .HasKey(up => new { up.IdRutina, up.IdEjercicio });

            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(up => up.Ejercicio)
                .WithMany(up => up.RutinaEjercicio)
                .HasForeignKey(up => up.IdEjercicio);

            modelBuilder.Entity<RutinaEjercicio>()
                .HasOne(up => up.Rutina)
                .WithMany(up => up.RutinaEjercicios)
                .HasForeignKey(up => up.IdRutina);

            //SocioRutinas
            modelBuilder.Entity<SocioRutina>()
                .HasKey(up => new { up.IdSocio, up.IdRutina });

            modelBuilder.Entity<SocioRutina>()
                .HasOne(up => up.Socio)
                .WithMany(up => up.SocioRutinas)
                .HasForeignKey(up => up.IdSocio);

            modelBuilder.Entity<SocioRutina>()
                .HasOne(up => up.Rutina)
                .WithMany(up => up.SocioRutinas)
                .HasForeignKey(up => up.IdRutina);

            //Configuracion para relacion N a 1
            modelBuilder.Entity<Maquina>()
                .HasOne(up => up.Local)
                .WithMany(up => up.Maquina)
                .HasForeignKey(up => up.IdLocal);

            //Relaciones 1 a 1
            //Locales - ResponsableLocal
            modelBuilder.Entity<Responsable>()
                .HasOne(up => up.Local)
                .WithOne(up => up.ResponsableLocal)
                .HasForeignKey<Local>(up => up.IdResponsableLocal);

            modelBuilder.Entity<TipoSocio>().HasData(
                new TipoSocio { Id = 1, Nombre = "Estandar" },
                new TipoSocio { Id = 2, Nombre = "Premium" });

            modelBuilder.Entity<TipoRutina>().HasData(
                new TipoRutina { Id = 1, Nombre = "Salud" },
                new TipoRutina { Id = 2, Nombre = "Competición amateur" },
                new TipoRutina { Id = 3, Nombre = "Competición profesional" }
                );
            modelBuilder.Entity<TipoMaquina>().HasData(
                new TipoMaquina { Id = 1, Nombre = "Ninguna", Descripcion = "Para realizar el ejercicio no se necesita una maquina en especifico"},
                new TipoMaquina { Id = 2, Nombre = "Mancuernas 1 Kg", Descripcion = "Mancuernas de peso ligero para entrenamiento" },
                new TipoMaquina { Id = 3, Nombre = "Prensa de Piernas", Descripcion = "Máquina para ejercitar los músculos de las piernas" },
                new TipoMaquina { Id = 4, Nombre = "Rack para Sentadilla", Descripcion = "Estructura para realizar sentadillas con barra" },
                new TipoMaquina { Id = 5, Nombre = "Caminadora", Descripcion = "Permite caminar o correr en un lugar" },
                new TipoMaquina { Id = 6, Nombre = "Bicicleta Estática", Descripcion = "Bicicleta para ejercicios cardiovasculares" },
                new TipoMaquina { Id = 7, Nombre = "Máquina de Remo", Descripcion = "Simula el movimiento de remar en agua" },
                new TipoMaquina { Id = 8, Nombre = "Press de Banca", Descripcion = "Máquina para ejercicios de pecho y tríceps" },
                new TipoMaquina { Id = 9, Nombre = "Peso Muerto", Descripcion = "Ejercicio de levantamiento de peso desde el suelo" },
                new TipoMaquina { Id = 10, Nombre = "Máquina de Cable Cruzado", Descripcion = "Permite realizar ejercicios de resistencia con cables" },
                new TipoMaquina { Id = 11, Nombre = "Máquina de Abdominales", Descripcion = "Para fortalecer los músculos abdominales" },
                new TipoMaquina { Id = 12, Nombre = "Escaladora", Descripcion = "Simulador de escalada para ejercicio cardiovascular" },
                new TipoMaquina { Id = 13, Nombre = "Banco de Pesas Ajustable", Descripcion = "Banco versátil para ejercicios con pesas" },
                new TipoMaquina { Id = 14, Nombre = "Bola Medicinal", Descripcion = "Bola ponderada para ejercicios de fuerza" },
                new TipoMaquina { Id = 15, Nombre = "Barra para Dominadas", Descripcion = "Estructura para realizar dominadas y ejercicios de suspensión" },
                new TipoMaquina { Id = 16, Nombre = "Polea Alta y Baja", Descripcion = "Máquina con poleas para ejercicios de resistencia" },
                new TipoMaquina { Id = 17, Nombre = "Máquina de Hombros", Descripcion = "Para entrenamiento de los músculos del hombro" },
                new TipoMaquina { Id = 18, Nombre = "Bicicleta Elíptica", Descripcion = "Ejercicio cardiovascular de bajo impacto" },
                new TipoMaquina { Id = 19, Nombre = "Máquina de Glúteos", Descripcion = "Para fortalecimiento de los músculos de los glúteos" },
                new TipoMaquina { Id = 20, Nombre = "Banco de Abdominales", Descripcion = "Banco específico para ejercicios de abdominales" },
                new TipoMaquina { Id = 21, Nombre = "Torre de Ejercicios", Descripcion = "Estructura versátil para ejercicios de cuerpo completo" },
                new TipoMaquina { Id = 22, Nombre = "Plataforma Vibratoria", Descripcion = "Estimula los músculos mediante vibraciones" },
                new TipoMaquina { Id = 23, Nombre = "Máquina de Curl Biceps", Descripcion = "Para ejercitar los músculos de los brazos" },
                new TipoMaquina { Id = 24, Nombre = "Step Aeróbico", Descripcion = "Plataforma para ejercicios aeróbicos y de piernas" },
                new TipoMaquina { Id = 25, Nombre = "Máquina de Flexiones", Descripcion = "Ayuda para realizar ejercicios de flexiones de brazos" },
                new TipoMaquina { Id = 26, Nombre = "Máquina de Espalda", Descripcion = "Fortalecimiento de los músculos de la espalda" },
                new TipoMaquina { Id = 27, Nombre = "Banco Inclinado", Descripcion = "Banco ajustable para entrenamiento de pecho" },
                new TipoMaquina { Id = 28, Nombre = "Máquina de Tríceps", Descripcion = "Ejercicios para tríceps con resistencia controlada" },
                new TipoMaquina { Id = 29, Nombre = "Bicicleta de Spinning", Descripcion = "Bicicleta estática para entrenamientos intensos" },
                new TipoMaquina { Id = 30, Nombre = "Máquina de Flexiones de Piernas", Descripcion = "Para ejercitar los músculos de las piernas" },
                new TipoMaquina { Id = 31, Nombre = "Banco Plano", Descripcion = "Banco para entrenamiento de pecho y brazos" }
                );
        }
    }


}
