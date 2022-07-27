using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactPersistence.Migrations
{
    public partial class UniqueConstraintToPropertyNameBusinessDepartmentAndPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BusinessPositions_Name",
                table: "BusinessPositions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDepartments_Name",
                table: "BusinessDepartments",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BusinessPositions_Name",
                table: "BusinessPositions");

            migrationBuilder.DropIndex(
                name: "IX_BusinessDepartments_Name",
                table: "BusinessDepartments");
        }
    }
}
