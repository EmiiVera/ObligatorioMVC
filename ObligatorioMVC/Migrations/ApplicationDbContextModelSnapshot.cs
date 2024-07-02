﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObligatorioMVC.Datos;

#nullable disable

namespace ObligatorioMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ObligatorioMVC.Models.Ejercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdTipoMaquina")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoMaquina");

                    b.ToTable("Ejercicio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Local", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdResponsableLocal")
                        .HasColumnType("int");

                    b.Property<string>("NombreLocal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TelefonoLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdResponsableLocal")
                        .IsUnique()
                        .HasFilter("[IdResponsableLocal] IS NOT NULL");

                    b.ToTable("Local");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Maquina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<int?>("IdTipoMaquina")
                        .HasColumnType("int");

                    b.Property<double>("PrecioCompra")
                        .HasColumnType("float");

                    b.Property<int>("VidaUtil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdLocal");

                    b.HasIndex("IdTipoMaquina");

                    b.ToTable("Maquina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Responsable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Sueldo")
                        .HasColumnType("float");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Responsable");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Rutina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionRutina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTipoRutina")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoRutina");

                    b.ToTable("Rutina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.RutinaEjercicio", b =>
                {
                    b.Property<int>("IdRutina")
                        .HasColumnType("int");

                    b.Property<int>("IdEjercicio")
                        .HasColumnType("int");

                    b.HasKey("IdRutina", "IdEjercicio");

                    b.HasIndex("IdEjercicio");

                    b.ToTable("RutinaEjercicios");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Socio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoSocio")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdLocal");

                    b.HasIndex("IdTipoSocio");

                    b.ToTable("Socio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.SocioRutina", b =>
                {
                    b.Property<int>("IdSocio")
                        .HasColumnType("int");

                    b.Property<int>("IdRutina")
                        .HasColumnType("int");

                    b.HasKey("IdSocio", "IdRutina");

                    b.HasIndex("IdRutina");

                    b.ToTable("SocioRutina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.TipoMaquina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoMaquina");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Para realizar el ejercicio no se necesita una maquina en especifico",
                            Nombre = "Ninguna"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Permite caminar o correr en un lugar",
                            Nombre = "Caminadora"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Permite movilidad sin tener que salir al exterior.",
                            Nombre = "Bicicleta Estática"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Simula el movimiento de caminar, correr o subir escaleras.",
                            Nombre = "Elíptica"
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Entrenamiento de fuerza que se enfoca específicamente en los cuádriceps, los glúteos y los isquiotibiales.",
                            Nombre = "Prensa de Pierna"
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = "Entrenamiento de fuerza que se utiliza para trabajar los músculos aductores de las piernas.",
                            Nombre = "Máquina de Aductor"
                        },
                        new
                        {
                            Id = 7,
                            Descripcion = "Fortalecimiento de los músculos del pecho, los hombros y los tríceps.",
                            Nombre = "Press de Banca"
                        },
                        new
                        {
                            Id = 8,
                            Descripcion = "Ejercicios de aislamiento para los isquiotibiales.",
                            Nombre = "Máquina para Femorales"
                        },
                        new
                        {
                            Id = 9,
                            Descripcion = "Sostiene el agarre y tira hacia abajo, cruzando los brazos en el proceso.",
                            Nombre = "Poleas Cruzadas"
                        },
                        new
                        {
                            Id = 10,
                            Descripcion = "Máquina de pectoral.",
                            Nombre = "Peck Deck"
                        },
                        new
                        {
                            Id = 11,
                            Descripcion = "Simula el movimiento de remar, trabaja varios grupos musculares.",
                            Nombre = "Remo"
                        },
                        new
                        {
                            Id = 12,
                            Descripcion = "Simula el subir escaleras, fortaleciendo las piernas y el sistema cardiovascular.",
                            Nombre = "Escaladora"
                        },
                        new
                        {
                            Id = 13,
                            Descripcion = "Aparato multifuncional para entrenamiento de fuerza guiado.",
                            Nombre = "Máquina Smith"
                        },
                        new
                        {
                            Id = 14,
                            Descripcion = "Permite ejercitar los músculos de los gemelos.",
                            Nombre = "Máquina de Gemelos"
                        },
                        new
                        {
                            Id = 15,
                            Descripcion = "Diseñada para trabajar y fortalecer los músculos abdominales.",
                            Nombre = "Máquina de Abdominales"
                        },
                        new
                        {
                            Id = 16,
                            Descripcion = "Permite realizar diferentes ejercicios en una misma máquina.",
                            Nombre = "Multifuncional"
                        },
                        new
                        {
                            Id = 17,
                            Descripcion = "Diseñada para trabajar y fortalecer los músculos glúteos.",
                            Nombre = "Máquina de Glúteos"
                        },
                        new
                        {
                            Id = 18,
                            Descripcion = "Fortalecimiento de los hombros y los tríceps.",
                            Nombre = "Press Militar"
                        },
                        new
                        {
                            Id = 19,
                            Descripcion = "Ejercicios específicos para trabajar los pectorales.",
                            Nombre = "Máquina de Pecho"
                        },
                        new
                        {
                            Id = 20,
                            Descripcion = "Aparato para fortalecer y definir los músculos del tríceps.",
                            Nombre = "Máquina de Tríceps"
                        },
                        new
                        {
                            Id = 21,
                            Descripcion = "Diseñada para trabajar y fortalecer los bíceps.",
                            Nombre = "Máquina de Bíceps"
                        },
                        new
                        {
                            Id = 22,
                            Descripcion = "Permite ejercitar la musculatura de la espalda.",
                            Nombre = "Máquina de Espalda"
                        },
                        new
                        {
                            Id = 23,
                            Descripcion = "Aparato para fortalecer los músculos de los hombros.",
                            Nombre = "Máquina de Hombros"
                        },
                        new
                        {
                            Id = 24,
                            Descripcion = "Entrenamiento de fuerza para los músculos abductores de las piernas.",
                            Nombre = "Máquina de Abductores"
                        },
                        new
                        {
                            Id = 25,
                            Descripcion = "Ejercita y fortalece los músculos de las pantorrillas.",
                            Nombre = "Máquina de gemelos"
                        },
                        new
                        {
                            Id = 26,
                            Descripcion = "Fortalece la musculatura de la zona dorsal y lumbar, corrige la postura corporal.",
                            Nombre = "Máquina Dorsales"
                        });
                });

            modelBuilder.Entity("ObligatorioMVC.Models.TipoRutina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoRutina");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Salud"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Competición amateur"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Competición profesional"
                        });
                });

            modelBuilder.Entity("ObligatorioMVC.Models.TipoSocio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoSocio");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Estandar"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Premium"
                        });
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Ejercicio", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.TipoMaquina", "TipoMaquina")
                        .WithMany()
                        .HasForeignKey("IdTipoMaquina");

                    b.Navigation("TipoMaquina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Local", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.Responsable", "ResponsableLocal")
                        .WithOne("Local")
                        .HasForeignKey("ObligatorioMVC.Models.Local", "IdResponsableLocal");

                    b.Navigation("ResponsableLocal");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Maquina", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.Local", "Local")
                        .WithMany("Maquina")
                        .HasForeignKey("IdLocal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObligatorioMVC.Models.TipoMaquina", "TipoMaquina")
                        .WithMany()
                        .HasForeignKey("IdTipoMaquina");

                    b.Navigation("Local");

                    b.Navigation("TipoMaquina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Rutina", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.TipoRutina", "TipoRutina")
                        .WithMany("Rutinas")
                        .HasForeignKey("IdTipoRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoRutina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.RutinaEjercicio", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.Ejercicio", "Ejercicio")
                        .WithMany("RutinaEjercicio")
                        .HasForeignKey("IdEjercicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObligatorioMVC.Models.Rutina", "Rutina")
                        .WithMany("RutinaEjercicios")
                        .HasForeignKey("IdRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ejercicio");

                    b.Navigation("Rutina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Socio", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.Local", "Local")
                        .WithMany("Socios")
                        .HasForeignKey("IdLocal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObligatorioMVC.Models.TipoSocio", "TipoSocio")
                        .WithMany("Socios")
                        .HasForeignKey("IdTipoSocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Local");

                    b.Navigation("TipoSocio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.SocioRutina", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.Rutina", "Rutina")
                        .WithMany("SocioRutinas")
                        .HasForeignKey("IdRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObligatorioMVC.Models.Socio", "Socio")
                        .WithMany("SocioRutinas")
                        .HasForeignKey("IdSocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rutina");

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Ejercicio", b =>
                {
                    b.Navigation("RutinaEjercicio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Local", b =>
                {
                    b.Navigation("Maquina");

                    b.Navigation("Socios");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Responsable", b =>
                {
                    b.Navigation("Local");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Rutina", b =>
                {
                    b.Navigation("RutinaEjercicios");

                    b.Navigation("SocioRutinas");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Socio", b =>
                {
                    b.Navigation("SocioRutinas");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.TipoRutina", b =>
                {
                    b.Navigation("Rutinas");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.TipoSocio", b =>
                {
                    b.Navigation("Socios");
                });
#pragma warning restore 612, 618
        }
    }
}
