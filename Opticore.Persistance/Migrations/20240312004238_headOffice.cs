using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opticore.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class headOffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_HeadOffice_HeadOfficeId",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Cp_HeadOffice_HeadOfficeId",
                table: "Cp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeadOffice",
                table: "HeadOffice");

            migrationBuilder.RenameTable(
                name: "HeadOffice",
                newName: "HeadOffices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeadOffices",
                table: "HeadOffices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_HeadOffices_HeadOfficeId",
                table: "ContactDetails",
                column: "HeadOfficeId",
                principalTable: "HeadOffices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cp_HeadOffices_HeadOfficeId",
                table: "Cp",
                column: "HeadOfficeId",
                principalTable: "HeadOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_HeadOffices_HeadOfficeId",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Cp_HeadOffices_HeadOfficeId",
                table: "Cp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeadOffices",
                table: "HeadOffices");

            migrationBuilder.RenameTable(
                name: "HeadOffices",
                newName: "HeadOffice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeadOffice",
                table: "HeadOffice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_HeadOffice_HeadOfficeId",
                table: "ContactDetails",
                column: "HeadOfficeId",
                principalTable: "HeadOffice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cp_HeadOffice_HeadOfficeId",
                table: "Cp",
                column: "HeadOfficeId",
                principalTable: "HeadOffice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}