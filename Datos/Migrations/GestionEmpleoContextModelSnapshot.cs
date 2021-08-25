﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(GestionEmpleoContext))]
    partial class GestionEmpleoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entidad.InformacionAcademica", b =>
                {
                    b.Property<int>("InformacionAcademicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("EstadoTipoFormacion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime");

                    b.Property<string>("Institucion")
                        .HasColumnType("text");

                    b.Property<string>("TipoFormacion")
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("InformacionAcademicaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ListadoInformacionAcademica");
                });

            modelBuilder.Entity("Entidad.InformacionLaboral", b =>
                {
                    b.Property<int>("InformacionLaboralId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cargo")
                        .HasColumnType("text");

                    b.Property<string>("Empresa")
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("InformacionLaboralId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ListadoInformacionLaboral");
                });

            modelBuilder.Entity("Entidad.Oferta", b =>
                {
                    b.Property<int>("OfertaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AnoExperiencia")
                        .HasColumnType("text");

                    b.Property<string>("Cargo")
                        .HasColumnType("text");

                    b.Property<string>("DiponibilidadViajar")
                        .HasColumnType("text");

                    b.Property<string>("DisponibilidadCambioResidendia")
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Resumen")
                        .HasColumnType("text");

                    b.Property<string>("Salario")
                        .HasColumnType("text");

                    b.Property<string>("TipoTrabajo")
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("OfertaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("Entidad.Postulacion", b =>
                {
                    b.Property<int>("PostulacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("EstadoPostulacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPostulacion")
                        .HasColumnType("datetime");

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("PostulacionId");

                    b.HasIndex("OfertaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Postulaciones");
                });

            modelBuilder.Entity("Entidad.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contrasena")
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("Entidad.Administrador", b =>
                {
                    b.HasBaseType("Entidad.Usuario");

                    b.Property<int>("Identificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("Entidad.Aspirante", b =>
                {
                    b.HasBaseType("Entidad.Usuario");

                    b.Property<string>("AnoExperiencia")
                        .HasColumnType("text");

                    b.Property<string>("Apellidos")
                        .HasColumnType("text");

                    b.Property<string>("Ciudad")
                        .HasColumnType("text");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("DiponibilidadViajar")
                        .HasColumnType("text");

                    b.Property<string>("DisponibilidadCambioResidendia")
                        .HasColumnType("text");

                    b.Property<string>("DisponibilidadViajar")
                        .HasColumnType("text");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("text");

                    b.Property<string>("Genero")
                        .HasColumnType("text");

                    b.Property<int>("Identificacion")
                        .HasColumnName("Aspirante_Identificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .HasColumnName("Aspirante_Nombres")
                        .HasColumnType("text");

                    b.Property<int?>("PostulacionId")
                        .HasColumnType("int");

                    b.Property<int>("Salario")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.Property<string>("TituloProfesional")
                        .HasColumnType("text");

                    b.HasIndex("PostulacionId");

                    b.HasDiscriminator().HasValue("Aspirante");
                });

            modelBuilder.Entity("Entidad.Empresa", b =>
                {
                    b.HasBaseType("Entidad.Usuario");

                    b.Property<string>("Ciudad")
                        .HasColumnName("Empresa_Ciudad")
                        .HasColumnType("text");

                    b.Property<string>("Descripcion")
                        .HasColumnName("Empresa_Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<int>("Nit")
                        .HasColumnType("int");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("text");

                    b.Property<string>("SitioWeb")
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnName("Empresa_Telefono")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Empresa");
                });

            modelBuilder.Entity("Entidad.InformacionAcademica", b =>
                {
                    b.HasOne("Entidad.Aspirante", "Aspirante")
                        .WithMany("FormacionAcademica")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.InformacionLaboral", b =>
                {
                    b.HasOne("Entidad.Aspirante", "Aspirante")
                        .WithMany("ExperienciaLaboral")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.Oferta", b =>
                {
                    b.HasOne("Entidad.Empresa", "Empresa")
                        .WithMany("Ofertas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.Postulacion", b =>
                {
                    b.HasOne("Entidad.Oferta", "Oferta")
                        .WithMany("Postulaciones")
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidad.Aspirante", "Aspirante")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidad.Aspirante", b =>
                {
                    b.HasOne("Entidad.Postulacion", null)
                        .WithMany("Aspirantes")
                        .HasForeignKey("PostulacionId");
                });
#pragma warning restore 612, 618
        }
    }
}
