using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeKeeper.Web.Migrations
{
    public partial class Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonModel",
                columns: table => new
                {
                    PersonModelId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModel", x => x.PersonModelId);
                });

            migrationBuilder.CreateTable(
                name: "AddressModel",
                columns: table => new
                {
                    AddressModelId = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PersonModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressModel", x => x.AddressModelId);
                    table.ForeignKey(
                        name: "FK_AddressModel_PersonModel_PersonModelId",
                        column: x => x.PersonModelId,
                        principalTable: "PersonModel",
                        principalColumn: "PersonModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberModel",
                columns: table => new
                {
                    PhoneNumberModelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    PersonModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberModel", x => x.PhoneNumberModelId);
                    table.ForeignKey(
                        name: "FK_PhoneNumberModel_PersonModel_PersonModelId",
                        column: x => x.PersonModelId,
                        principalTable: "PersonModel",
                        principalColumn: "PersonModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectModelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CustomerPersonModelId = table.Column<Guid>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectModelId);
                    table.ForeignKey(
                        name: "FK_Projects_PersonModel_CustomerPersonModelId",
                        column: x => x.CustomerPersonModelId,
                        principalTable: "PersonModel",
                        principalColumn: "PersonModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyModelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    VatId = table.Column<string>(nullable: true),
                    AddressModelId = table.Column<Guid>(nullable: true),
                    ContactPersonModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyModelId);
                    table.ForeignKey(
                        name: "FK_Companies_AddressModel_AddressModelId",
                        column: x => x.AddressModelId,
                        principalTable: "AddressModel",
                        principalColumn: "AddressModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_PersonModel_ContactPersonModelId",
                        column: x => x.ContactPersonModelId,
                        principalTable: "PersonModel",
                        principalColumn: "PersonModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionModel",
                columns: table => new
                {
                    SessionModelId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ProjectModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionModel", x => x.SessionModelId);
                    table.ForeignKey(
                        name: "FK_SessionModel_Projects_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "Projects",
                        principalColumn: "ProjectModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressModel_PersonModelId",
                table: "AddressModel",
                column: "PersonModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressModelId",
                table: "Companies",
                column: "AddressModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ContactPersonModelId",
                table: "Companies",
                column: "ContactPersonModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumberModel_PersonModelId",
                table: "PhoneNumberModel",
                column: "PersonModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerPersonModelId",
                table: "Projects",
                column: "CustomerPersonModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionModel_ProjectModelId",
                table: "SessionModel",
                column: "ProjectModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "PhoneNumberModel");

            migrationBuilder.DropTable(
                name: "SessionModel");

            migrationBuilder.DropTable(
                name: "AddressModel");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "PersonModel");
        }
    }
}
