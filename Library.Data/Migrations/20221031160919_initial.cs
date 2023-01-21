using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GradoEscolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradoEscolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoActividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoActividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ap1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ap2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradoEscolarID = table.Column<int>(type: "int", nullable: false),
                    PadreID = table.Column<int>(type: "int", nullable: false),
                    MadreID = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PIS = table.Column<bool>(type: "bit", nullable: true),
                    Hora = table.Column<double>(type: "float", nullable: true),
                    TienePermisoIrse = table.Column<bool>(type: "bit", nullable: true),
                    CentroTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_GradoEscolar_GradoEscolarID",
                        column: x => x.GradoEscolarID,
                        principalTable: "GradoEscolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_Persona_MadreID",
                        column: x => x.MadreID,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Persona_PadreID",
                        column: x => x.PadreID,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Provincias_ProvinciaID",
                        column: x => x.ProvinciaID,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoActividadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_TipoActividades_TipoActividadID",
                        column: x => x.TipoActividadID,
                        principalTable: "TipoActividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Iglesias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MunicipioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iglesias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Iglesias_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActividadID = table.Column<int>(type: "int", nullable: false),
                    NinoID = table.Column<int>(type: "int", nullable: false),
                    PersonaMayorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participaciones_Actividades_ActividadID",
                        column: x => x.ActividadID,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participaciones_Persona_NinoID",
                        column: x => x.NinoID,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participaciones_Persona_PersonaMayorID",
                        column: x => x.PersonaMayorID,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Final = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IglesiaID = table.Column<int>(type: "int", nullable: false),
                    CoordinadorID = table.Column<int>(type: "int", nullable: false),
                    AdministradorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Iglesias_IglesiaID",
                        column: x => x.IglesiaID,
                        principalTable: "Iglesias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proyectos_Persona_AdministradorID",
                        column: x => x.AdministradorID,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Persona_CoordinadorID",
                        column: x => x.CoordinadorID,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoID = table.Column<int>(type: "int", nullable: false),
                    NinoID = table.Column<int>(type: "int", nullable: false),
                    ResponsableID = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Horarios_HorarioID",
                        column: x => x.HorarioID,
                        principalTable: "Horarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Persona_NinoID",
                        column: x => x.NinoID,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Persona_ResponsableID",
                        column: x => x.ResponsableID,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matriculas_Proyectos_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GradoEscolar",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Pre-esolar" },
                    { 2, "Primero" },
                    { 3, "Segundo" },
                    { 4, "Tercero" },
                    { 5, "Cuarto" },
                    { 6, "Quinto" },
                    { 7, "Sexto" },
                    { 8, "Séptimo" },
                    { 9, "Octavo" },
                    { 10, "Noveno" }
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Pinar del Río" },
                    { 2, "Artemisa" },
                    { 3, "La Habana" },
                    { 4, "Mayabeque" },
                    { 5, "La isla de la Juventud" },
                    { 6, "Matanzas" },
                    { 7, "Villa Clara" },
                    { 8, "Cienfuegos" },
                    { 9, "Sancti Spíritus" },
                    { 10, "Ciego de Ávila" },
                    { 11, "Camagüey" },
                    { 12, "Las Tunas" },
                    { 13, "Holguín" },
                    { 14, "Granma" },
                    { 15, "Santiago de Cuba" },
                    { 16, "Guantánamo" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaID" },
                values: new object[,]
                {
                    { 1, "Matanzas", 6 },
                    { 2, "Cárdenas", 6 },
                    { 3, "Martí", 6 },
                    { 4, "Colón", 6 },
                    { 5, "Perico", 6 },
                    { 6, "Jovellanos", 6 },
                    { 7, "Pedro Betancourt", 6 },
                    { 8, "Limonar", 6 },
                    { 9, "Unión de Reyes", 6 },
                    { 10, "Ciénaga de Zapata", 6 },
                    { 11, "Jagüey Grande", 6 },
                    { 12, "Calimet", 6 },
                    { 13, "Los Arabos", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_TipoActividadID",
                table: "Actividades",
                column: "TipoActividadID");

            migrationBuilder.CreateIndex(
                name: "IX_Iglesias_Id",
                table: "Iglesias",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Iglesias_MunicipioID",
                table: "Iglesias",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Iglesias_Nombre",
                table: "Iglesias",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_HorarioID",
                table: "Matriculas",
                column: "HorarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_Id",
                table: "Matriculas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_NinoID_ProyectoID",
                table: "Matriculas",
                columns: new[] { "NinoID", "ProyectoID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_ProyectoID",
                table: "Matriculas",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_ResponsableID",
                table: "Matriculas",
                column: "ResponsableID");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaID",
                table: "Municipios",
                column: "ProvinciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_ActividadID",
                table: "Participaciones",
                column: "ActividadID");

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_Id",
                table: "Participaciones",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_NinoID_ActividadID",
                table: "Participaciones",
                columns: new[] { "NinoID", "ActividadID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participaciones_PersonaMayorID",
                table: "Participaciones",
                column: "PersonaMayorID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CI",
                table: "Persona",
                column: "CI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_GradoEscolarID",
                table: "Persona",
                column: "GradoEscolarID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Id",
                table: "Persona",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_MadreID",
                table: "Persona",
                column: "MadreID");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_PadreID",
                table: "Persona",
                column: "PadreID");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_AdministradorID",
                table: "Proyectos",
                column: "AdministradorID");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_CoordinadorID",
                table: "Proyectos",
                column: "CoordinadorID");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Id",
                table: "Proyectos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_IglesiaID",
                table: "Proyectos",
                column: "IglesiaID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoActividades_Id",
                table: "TipoActividades",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoActividades_Nombre",
                table: "TipoActividades",
                column: "Nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Participaciones");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Iglesias");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "TipoActividades");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "GradoEscolar");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}
