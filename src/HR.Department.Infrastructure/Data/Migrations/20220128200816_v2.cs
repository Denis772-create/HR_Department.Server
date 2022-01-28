using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Department.Infrastructure.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionEmployee_Employees_EmployeeId",
                table: "PositionEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionEmployee_Positions_PositionId",
                table: "PositionEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionEmployee",
                table: "PositionEmployee");

            migrationBuilder.RenameTable(
                name: "PositionEmployee",
                newName: "PositionEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_PositionEmployee_EmployeeId",
                table: "PositionEmployees",
                newName: "IX_PositionEmployees_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionEmployees",
                table: "PositionEmployees",
                columns: new[] { "PositionId", "EmployeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PositionEmployees_Employees_EmployeeId",
                table: "PositionEmployees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionEmployees_Positions_PositionId",
                table: "PositionEmployees",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionEmployees_Employees_EmployeeId",
                table: "PositionEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionEmployees_Positions_PositionId",
                table: "PositionEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionEmployees",
                table: "PositionEmployees");

            migrationBuilder.RenameTable(
                name: "PositionEmployees",
                newName: "PositionEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_PositionEmployees_EmployeeId",
                table: "PositionEmployee",
                newName: "IX_PositionEmployee_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionEmployee",
                table: "PositionEmployee",
                columns: new[] { "PositionId", "EmployeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PositionEmployee_Employees_EmployeeId",
                table: "PositionEmployee",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionEmployee_Positions_PositionId",
                table: "PositionEmployee",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
