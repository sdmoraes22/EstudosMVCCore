using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSOFT.AppModelo.Migrations
{
    public partial class RemoveTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Alunos",
                nullable: true);
        }
    }
}
