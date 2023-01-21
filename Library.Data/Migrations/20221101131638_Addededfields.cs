using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class Addededfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacidad",
                table: "Proyectos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMatriculado",
                table: "Matriculas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacidad",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "IsMatriculado",
                table: "Matriculas");
        }
    }
}
