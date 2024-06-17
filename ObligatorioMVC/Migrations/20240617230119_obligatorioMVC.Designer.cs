﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObligatorioMVC.Datos;

#nullable disable

namespace ObligatorioMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240617230119_obligatorioMVC")]
    partial class obligatorioMVC
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ObligatorioMVC.Models.Ejercicio", b =>
                {
                    b.Property<int>("IdEjercicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEjercicio"));

                    b.Property<int>("IdTipoMaquina")
                        .HasColumnType("int");

                    b.Property<int?>("tipoMaquinaidTipoMaquina")
                        .HasColumnType("int");

                    b.HasKey("IdEjercicio");

                    b.HasIndex("tipoMaquinaidTipoMaquina");

                    b.ToTable("Ejercicio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Local", b =>
                {
                    b.Property<int>("IdLocal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLocal"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdMaquina")
                        .HasColumnType("int");

                    b.Property<string>("NombreLocal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TelefonoLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idResponsableLocal")
                        .HasColumnType("int");

                    b.HasKey("IdLocal");

                    b.HasIndex("idResponsableLocal");

                    b.ToTable("Local");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Maquina", b =>
                {
                    b.Property<int>("IdMaquina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMaquina"));

                    b.Property<string>("Disponibilidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoMaquina")
                        .HasColumnType("int");

                    b.Property<double>("PrecioCompra")
                        .HasColumnType("float");

                    b.Property<DateTime>("VidaUtil")
                        .HasColumnType("datetime2");

                    b.Property<int?>("localIdLocal")
                        .HasColumnType("int");

                    b.HasKey("IdMaquina");

                    b.HasIndex("IdTipoMaquina");

                    b.HasIndex("localIdLocal");

                    b.ToTable("Maquina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Rutina", b =>
                {
                    b.Property<int>("IdRutina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRutina"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Promedio")
                        .HasColumnType("float");

                    b.Property<int>("tipoRutina")
                        .HasColumnType("int");

                    b.HasKey("IdRutina");

                    b.HasIndex("tipoRutina");

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

                    b.ToTable("rutinaEjercicios");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.SocioRutina", b =>
                {
                    b.Property<int>("idSocio")
                        .HasColumnType("int");

                    b.Property<int>("idRutina")
                        .HasColumnType("int");

                    b.HasKey("idSocio", "idRutina");

                    b.HasIndex("idRutina");

                    b.ToTable("SocioRutina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.TipoMaquina", b =>
                {
                    b.Property<int>("idTipoMaquina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTipoMaquina"));

                    b.Property<string>("nombreTipoMaquina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idTipoMaquina");

                    b.ToTable("TipoMaquina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.TipoRutina", b =>
                {
                    b.Property<int>("IdTipoRutina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoRutina"));

                    b.Property<string>("NombreTipoRutina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoRutina");

                    b.ToTable("TipoRutina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.TipoSocio", b =>
                {
                    b.Property<int>("IdTipoSocio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoSocio"));

                    b.Property<string>("NombreTipoSocio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoSocio");

                    b.ToTable("TipoSocio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ObligatorioMVC.Models.ResponsableLocal", b =>
                {
                    b.HasBaseType("ObligatorioMVC.Models.Usuario");

                    b.HasDiscriminator().HasValue("ResponsableLocal");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Socio", b =>
                {
                    b.HasBaseType("ObligatorioMVC.Models.Usuario");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<int?>("TipoSocio")
                        .HasColumnType("int");

                    b.Property<int>("localIdLocal")
                        .HasColumnType("int");

                    b.HasIndex("TipoSocio");

                    b.HasIndex("localIdLocal");

                    b.HasDiscriminator().HasValue("Socio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Ejercicio", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.TipoMaquina", "tipoMaquina")
                        .WithMany()
                        .HasForeignKey("tipoMaquinaidTipoMaquina");

                    b.Navigation("tipoMaquina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Local", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.ResponsableLocal", "ResponsableLocal")
                        .WithMany()
                        .HasForeignKey("idResponsableLocal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResponsableLocal");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Maquina", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.TipoMaquina", "TipoMaquina")
                        .WithMany()
                        .HasForeignKey("IdTipoMaquina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObligatorioMVC.Models.Local", "local")
                        .WithMany("Maquinas")
                        .HasForeignKey("localIdLocal");

                    b.Navigation("TipoMaquina");

                    b.Navigation("local");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Rutina", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.TipoRutina", "TipoRutina")
                        .WithMany()
                        .HasForeignKey("tipoRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoRutina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.RutinaEjercicio", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.Ejercicio", "Ejercicio")
                        .WithMany("rutinaEjercicios")
                        .HasForeignKey("IdEjercicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObligatorioMVC.Models.Rutina", "Rutina")
                        .WithMany("rutinaEjercicios")
                        .HasForeignKey("IdRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ejercicio");

                    b.Navigation("Rutina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.SocioRutina", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.Rutina", "Rutina")
                        .WithMany("socioRutinas")
                        .HasForeignKey("idRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObligatorioMVC.Models.Socio", "Socio")
                        .WithMany("socioRutinas")
                        .HasForeignKey("idSocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rutina");

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Socio", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.TipoSocio", "tipoSocio")
                        .WithMany()
                        .HasForeignKey("TipoSocio");

                    b.HasOne("ObligatorioMVC.Models.Local", "local")
                        .WithMany()
                        .HasForeignKey("localIdLocal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("local");

                    b.Navigation("tipoSocio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Ejercicio", b =>
                {
                    b.Navigation("rutinaEjercicios");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Local", b =>
                {
                    b.Navigation("Maquinas");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Rutina", b =>
                {
                    b.Navigation("rutinaEjercicios");

                    b.Navigation("socioRutinas");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Socio", b =>
                {
                    b.Navigation("socioRutinas");
                });
#pragma warning restore 612, 618
        }
    }
}