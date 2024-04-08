using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipments.Identity.Migrations
{
    public partial class AddColumnDescriptionOfRoleRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RoleRequest",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "RoleRequest");
        }
    }
}
