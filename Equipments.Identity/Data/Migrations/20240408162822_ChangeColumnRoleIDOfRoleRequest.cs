using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipments.Identity.Migrations
{
    public partial class ChangeColumnRoleIDOfRoleRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "RoleRequest",
                newName: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRequest_RoleId",
                table: "RoleRequest",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRequest_AspNetRoles_RoleId",
                table: "RoleRequest",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleRequest_AspNetRoles_RoleId",
                table: "RoleRequest");

            migrationBuilder.DropIndex(
                name: "IX_RoleRequest_RoleId",
                table: "RoleRequest");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "RoleRequest",
                newName: "RoleName");
        }
    }
}
