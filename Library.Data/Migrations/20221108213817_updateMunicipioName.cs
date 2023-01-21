using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class updateMunicipioName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Update Municipios SET Nombre = 'Calimete' WHERE Id=12");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
