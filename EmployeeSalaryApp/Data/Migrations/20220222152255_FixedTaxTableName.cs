using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSalaryApp.Data.Migrations
{
    public partial class FixedTaxTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "TaxValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxValues",
                table: "TaxValues",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxValues",
                table: "TaxValues");

            migrationBuilder.RenameTable(
                name: "TaxValues",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");
        }
    }
}
