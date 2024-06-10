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
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ObligatorioMVC.Models.Ejercicio", b =>
                {
                    b.Property<int>("IdEjercicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEjercicio"), 1L, 1);

                    b.Property<int?>("MaquinaIdMaquina")
                        .HasColumnType("int");

                    b.HasKey("IdEjercicio");

                    b.HasIndex("MaquinaIdMaquina");

                    b.ToTable("Ejercicio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Local", b =>
                {
                    b.Property<int>("IdLocal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLocal"), 1L, 1);

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreLocal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ResponsableLocalIdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("TelefonoLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLocal");

                    b.HasIndex("ResponsableLocalIdUsuario");

                    b.ToTable("Local");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Maquina", b =>
                {
                    b.Property<int>("IdMaquina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMaquina"), 1L, 1);

                    b.Property<string>("Disponibilidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LocalIdLocal")
                        .HasColumnType("int");

                    b.Property<double>("PrecioCompra")
                        .HasColumnType("float");

                    b.Property<int?>("TipoMaquinaidTipoMaquina")
                        .HasColumnType("int");

                    b.Property<DateTime>("VidaUtil")
                        .HasColumnType("datetime2");

                    b.HasKey("IdMaquina");

                    b.HasIndex("LocalIdLocal");

                    b.HasIndex("TipoMaquinaidTipoMaquina");

                    b.ToTable("Maquina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Rutina", b =>
                {
                    b.Property<int>("IdRutina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRutina"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Promedio")
                        .HasColumnType("float");

                    b.Property<string>("TipoRutina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRutina");

                    b.ToTable("Rutina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.TipoMaquina", b =>
                {
                    b.Property<int>("idTipoMaquina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTipoMaquina"), 1L, 1);

                    b.Property<string>("nombreTipoMaquina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idTipoMaquina");

                    b.ToTable("TipoMaquina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.ResponsableLocal", b =>
                {
                    b.HasBaseType("ObligatorioMVC.Models.Usuario");

                    b.HasDiscriminator().HasValue("ResponsableLocal");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Socio", b =>
                {
                    b.HasBaseType("ObligatorioMVC.Models.Usuario");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("localIdLocal")
                        .HasColumnType("int");

                    b.HasIndex("localIdLocal");

                    b.HasDiscriminator().HasValue("Socio");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Ejercicio", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.Maquina", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaIdMaquina");

                    b.Navigation("Maquina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Local", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.ResponsableLocal", "ResponsableLocal")
                        .WithMany()
                        .HasForeignKey("ResponsableLocalIdUsuario");

                    b.Navigation("ResponsableLocal");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Maquina", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.Local", null)
                        .WithMany("Maquinas")
                        .HasForeignKey("LocalIdLocal");

                    b.HasOne("ObligatorioMVC.Models.TipoMaquina", "TipoMaquina")
                        .WithMany()
                        .HasForeignKey("TipoMaquinaidTipoMaquina");

                    b.Navigation("TipoMaquina");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Socio", b =>
                {
                    b.HasOne("ObligatorioMVC.Models.Local", "local")
                        .WithMany()
                        .HasForeignKey("localIdLocal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("local");
                });

            modelBuilder.Entity("ObligatorioMVC.Models.Local", b =>
                {
                    b.Navigation("Maquinas");
                });
#pragma warning restore 612, 618
        }
    }
}
