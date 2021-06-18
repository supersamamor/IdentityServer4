using Microsoft.EntityFrameworkCore.Migrations;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.SqlServer.Migrations.Identity
{
    public partial class AddRelationOnRoleClaimAndApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "RoleClaims",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Permission",
                table: "RoleClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_ApplicationId",
                table: "RoleClaims",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Applications_ApplicationId",
                table: "RoleClaims",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Applications_ApplicationId",
                table: "RoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_RoleClaims_ApplicationId",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "RoleClaims");
        }
    }
}
