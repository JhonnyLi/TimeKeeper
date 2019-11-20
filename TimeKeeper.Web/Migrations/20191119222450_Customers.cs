using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeKeeper.Web.Migrations
{
    public partial class Customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressModel_PersonModel_PersonModelId",
                table: "AddressModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_PersonModel_ContactPersonModelId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumberModel_PersonModel_PersonModelId",
                table: "PhoneNumberModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_PersonModel_CustomerPersonModelId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonModel",
                table: "PersonModel");

            migrationBuilder.RenameTable(
                name: "PersonModel",
                newName: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Street2",
                table: "AddressModel",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "AddressModel",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "AddressModel",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "AddressModel",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "AddressModel",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AddressModel",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Customers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "PersonModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_Customers_PersonModelId",
                table: "AddressModel",
                column: "PersonModelId",
                principalTable: "Customers",
                principalColumn: "PersonModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Customers_ContactPersonModelId",
                table: "Companies",
                column: "ContactPersonModelId",
                principalTable: "Customers",
                principalColumn: "PersonModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumberModel_Customers_PersonModelId",
                table: "PhoneNumberModel",
                column: "PersonModelId",
                principalTable: "Customers",
                principalColumn: "PersonModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerPersonModelId",
                table: "Projects",
                column: "CustomerPersonModelId",
                principalTable: "Customers",
                principalColumn: "PersonModelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressModel_Customers_PersonModelId",
                table: "AddressModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Customers_ContactPersonModelId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumberModel_Customers_PersonModelId",
                table: "PhoneNumberModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerPersonModelId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "PersonModel");

            migrationBuilder.AlterColumn<string>(
                name: "Street2",
                table: "AddressModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "AddressModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "AddressModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "County",
                table: "AddressModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "AddressModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AddressModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "PersonModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "PersonModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "PersonModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "PersonModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonModel",
                table: "PersonModel",
                column: "PersonModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_PersonModel_PersonModelId",
                table: "AddressModel",
                column: "PersonModelId",
                principalTable: "PersonModel",
                principalColumn: "PersonModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_PersonModel_ContactPersonModelId",
                table: "Companies",
                column: "ContactPersonModelId",
                principalTable: "PersonModel",
                principalColumn: "PersonModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumberModel_PersonModel_PersonModelId",
                table: "PhoneNumberModel",
                column: "PersonModelId",
                principalTable: "PersonModel",
                principalColumn: "PersonModelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_PersonModel_CustomerPersonModelId",
                table: "Projects",
                column: "CustomerPersonModelId",
                principalTable: "PersonModel",
                principalColumn: "PersonModelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
