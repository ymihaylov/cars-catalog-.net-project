using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsCatalog.Migrations
{
    public partial class UpdateDB10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Approved",
                table: "Comments",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Comments",
                newName: "Approved");
        }
    }
}
