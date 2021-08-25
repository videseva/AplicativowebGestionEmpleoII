using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postulaciones",
                columns: table => new
                {
                    PostulacionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    OfertaId = table.Column<int>(nullable: false),
                    FechaPostulacion = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    EstadoPostulacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postulaciones", x => x.PostulacionId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TipoUsuario = table.Column<int>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Identificacion = table.Column<int>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Aspirante_Identificacion = table.Column<int>(nullable: true),
                    Aspirante_Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Genero = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: true),
                    AnoExperiencia = table.Column<string>(nullable: true),
                    DiponibilidadViajar = table.Column<string>(nullable: true),
                    TituloProfesional = table.Column<string>(nullable: true),
                    EstadoCivil = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Salario = table.Column<int>(nullable: true),
                    DisponibilidadViajar = table.Column<string>(nullable: true),
                    DisponibilidadCambioResidendia = table.Column<string>(nullable: true),
                    PostulacionId = table.Column<int>(nullable: true),
                    Nit = table.Column<int>(nullable: true),
                    RazonSocial = table.Column<string>(nullable: true),
                    Empresa_Telefono = table.Column<string>(nullable: true),
                    Empresa_Ciudad = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Empresa_Descripcion = table.Column<string>(nullable: true),
                    SitioWeb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Postulaciones_PostulacionId",
                        column: x => x.PostulacionId,
                        principalTable: "Postulaciones",
                        principalColumn: "PostulacionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListadoInformacionAcademica",
                columns: table => new
                {
                    InformacionAcademicaId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    Institucion = table.Column<string>(nullable: true),
                    TipoFormacion = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    EstadoTipoFormacion = table.Column<string>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListadoInformacionAcademica", x => x.InformacionAcademicaId);
                    table.ForeignKey(
                        name: "FK_ListadoInformacionAcademica_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListadoInformacionLaboral",
                columns: table => new
                {
                    InformacionLaboralId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    Empresa = table.Column<string>(nullable: true),
                    Cargo = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListadoInformacionLaboral", x => x.InformacionLaboralId);
                    table.ForeignKey(
                        name: "FK_ListadoInformacionLaboral_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    OfertaId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    Resumen = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Salario = table.Column<string>(nullable: true),
                    Cargo = table.Column<string>(nullable: true),
                    TipoTrabajo = table.Column<string>(nullable: true),
                    AnoExperiencia = table.Column<string>(nullable: true),
                    DiponibilidadViajar = table.Column<string>(nullable: true),
                    DisponibilidadCambioResidendia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.OfertaId);
                    table.ForeignKey(
                        name: "FK_Ofertas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListadoInformacionAcademica_UsuarioId",
                table: "ListadoInformacionAcademica",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListadoInformacionLaboral_UsuarioId",
                table: "ListadoInformacionLaboral",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_UsuarioId",
                table: "Ofertas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Postulaciones_OfertaId",
                table: "Postulaciones",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Postulaciones_UsuarioId",
                table: "Postulaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PostulacionId",
                table: "Usuario",
                column: "PostulacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postulaciones_Usuario_UsuarioId",
                table: "Postulaciones",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Postulaciones_Ofertas_OfertaId",
                table: "Postulaciones",
                column: "OfertaId",
                principalTable: "Ofertas",
                principalColumn: "OfertaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_Usuario_UsuarioId",
                table: "Ofertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Postulaciones_Usuario_UsuarioId",
                table: "Postulaciones");

            migrationBuilder.DropTable(
                name: "ListadoInformacionAcademica");

            migrationBuilder.DropTable(
                name: "ListadoInformacionLaboral");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Postulaciones");

            migrationBuilder.DropTable(
                name: "Ofertas");
        }
    }
}
