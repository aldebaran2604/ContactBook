using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactPersistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessDepartments",
                columns: table => new
                {
                    BusinessDepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDepartments", x => x.BusinessDepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPositions",
                columns: table => new
                {
                    BusinessPositionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPositions", x => x.BusinessPositionId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Names = table.Column<string>(type: "TEXT", nullable: true),
                    LastNames = table.Column<string>(type: "TEXT", nullable: true),
                    Pseudonymous = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessPositionID = table.Column<int>(type: "INTEGER", nullable: true),
                    BusinessDepartmentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_BusinessDepartments_BusinessDepartmentId",
                        column: x => x.BusinessDepartmentId,
                        principalTable: "BusinessDepartments",
                        principalColumn: "BusinessDepartmentId");
                    table.ForeignKey(
                        name: "FK_Contacts_BusinessPositions_BusinessPositionID",
                        column: x => x.BusinessPositionID,
                        principalTable: "BusinessPositions",
                        principalColumn: "BusinessPositionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BusinessDepartmentId",
                table: "Contacts",
                column: "BusinessDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BusinessPositionID",
                table: "Contacts",
                column: "BusinessPositionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "BusinessDepartments");

            migrationBuilder.DropTable(
                name: "BusinessPositions");
        }
    }
}
