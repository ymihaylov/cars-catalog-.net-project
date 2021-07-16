using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsCatalog.Migrations
{
    public partial class UpdateDB13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disapproved",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disapproved",
                table: "Comments");
        }
    }
}
