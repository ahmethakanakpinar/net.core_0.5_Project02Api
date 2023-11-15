using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class include_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppRoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppRoleId",
                table: "AspNetUsers",
                column: "AppRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_AppRoleId",
                table: "AspNetUsers",
                column: "AppRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_AppRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AppRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");
        }
    }
}
