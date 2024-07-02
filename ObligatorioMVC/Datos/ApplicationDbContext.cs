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
        public DbSet<Ejercicio> Ejercicio { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Maquina> Maquina { get; set; }
        public DbSet<Responsable> Responsable { get; set; }
        public DbSet<Rutina> Rutina { get; set; }
        public DbSet<RutinaEjercicio> RutinaEjercicios { get; set; }
        public DbSet<Socio> Socio { get; set; }
        public DbSet<SocioRutina> SocioRutina { get; set; }
        public DbSet<TipoMaquina> TipoMaquina { get; set; }
        public DbSet<TipoRutina> TipoRutina { get; set; }
        public DbSet<TipoSocio> TipoSocio { get; set; }

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

            //SocioRutina
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
            //Local - ResponsableLocal
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
                new TipoMaquina { Id= 1, Nombre = "Ninguna", Descripcion = "Para realizar el ejercicio no se necesita una maquina en especifico"},
                new TipoMaquina { Id = 2, Nombre = "Caminadora", Descripcion = "Permite caminar o correr en un lugar" },
                new TipoMaquina { Id = 3, Nombre = "Bicicleta Estática", Descripcion = "Permite movilidad sin tener que salir al exterior." },
                new TipoMaquina { Id = 4, Nombre = "Elíptica", Descripcion = "Simula el movimiento de caminar, correr o subir escaleras." },
                new TipoMaquina { Id = 5, Nombre = "Prensa de Pierna", Descripcion = "Entrenamiento de fuerza que se enfoca específicamente en los cuádriceps, los glúteos y los isquiotibiales." },
                new TipoMaquina { Id = 6, Nombre = "Máquina de Aductor", Descripcion = "Entrenamiento de fuerza que se utiliza para trabajar los músculos aductores de las piernas." },
                new TipoMaquina { Id = 7, Nombre = "Press de Banca", Descripcion = "Fortalecimiento de los músculos del pecho, los hombros y los tríceps." },
                new TipoMaquina { Id = 8, Nombre = "Máquina para Femorales", Descripcion = "Ejercicios de aislamiento para los isquiotibiales." },
                new TipoMaquina { Id = 9, Nombre = "Poleas Cruzadas", Descripcion = "Sostiene el agarre y tira hacia abajo, cruzando los brazos en el proceso." },
                new TipoMaquina { Id = 10, Nombre = "Peck Deck", Descripcion = "Máquina de pectoral." },
                new TipoMaquina { Id = 11, Nombre = "Remo", Descripcion = "Simula el movimiento de remar, trabaja varios grupos musculares." },
                new TipoMaquina { Id = 12, Nombre = "Escaladora", Descripcion = "Simula el subir escaleras, fortaleciendo las piernas y el sistema cardiovascular." },
                new TipoMaquina { Id = 13, Nombre = "Máquina Smith", Descripcion = "Aparato multifuncional para entrenamiento de fuerza guiado." },
                new TipoMaquina { Id = 14, Nombre = "Máquina de Gemelos", Descripcion = "Permite ejercitar los músculos de los gemelos." },
                new TipoMaquina { Id = 15, Nombre = "Máquina de Abdominales", Descripcion = "Diseñada para trabajar y fortalecer los músculos abdominales." },
                new TipoMaquina { Id = 16, Nombre = "Multifuncional", Descripcion = "Permite realizar diferentes ejercicios en una misma máquina." },
                new TipoMaquina { Id = 17, Nombre = "Máquina de Glúteos", Descripcion = "Diseñada para trabajar y fortalecer los músculos glúteos." },
                new TipoMaquina { Id = 18, Nombre = "Press Militar", Descripcion = "Fortalecimiento de los hombros y los tríceps." },
                new TipoMaquina { Id = 19, Nombre = "Máquina de Pecho", Descripcion = "Ejercicios específicos para trabajar los pectorales." },
                new TipoMaquina { Id = 20, Nombre = "Máquina de Tríceps", Descripcion = "Aparato para fortalecer y definir los músculos del tríceps." },
                new TipoMaquina { Id = 21, Nombre = "Máquina de Bíceps", Descripcion = "Diseñada para trabajar y fortalecer los bíceps." },
                new TipoMaquina { Id = 22, Nombre = "Máquina de Espalda", Descripcion = "Permite ejercitar la musculatura de la espalda." },
                new TipoMaquina { Id = 23, Nombre = "Máquina de Hombros", Descripcion = "Aparato para fortalecer los músculos de los hombros." },
                new TipoMaquina { Id = 24, Nombre = "Máquina de Abductores", Descripcion = "Entrenamiento de fuerza para los músculos abductores de las piernas." },
                new TipoMaquina { Id = 25, Nombre = "Máquina de gemelos", Descripcion = "Ejercita y fortalece los músculos de las pantorrillas." },
                new TipoMaquina { Id = 26, Nombre = "Máquina Dorsales", Descripcion = "Fortalece la musculatura de la zona dorsal y lumbar, corrige la postura corporal." }
                );
        }
    }


}
