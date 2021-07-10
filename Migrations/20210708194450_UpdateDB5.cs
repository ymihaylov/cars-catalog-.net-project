using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsCatalog.Migrations
{
    public partial class UpdateDB5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "CarModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "CarModel");
        }
    }
}
