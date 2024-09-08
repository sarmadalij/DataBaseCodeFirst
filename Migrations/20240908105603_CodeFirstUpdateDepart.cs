using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class CodeFirstUpdateDepart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Students",
                newName: "StudentDepartment");

            migrationBuilder.AlterColumn<string>(
                name: "StudentDepartment",
                table: "Students",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentDepartment",
                table: "Students",
                newName: "Department");

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }
    }
}
