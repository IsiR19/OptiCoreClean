using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opticore.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updateCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Companies_CompanyId",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_CompanyId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ContactDetails");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UUID",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UUID",
                table: "Users");


            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "ContactDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_CompanyId",
                table: "ContactDetails",
                column: "CompanyId");


            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Companies_CompanyId",
                table: "ContactDetails",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
