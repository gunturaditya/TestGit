using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStudy1.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityEmployeROLE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "TB_M_Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "TB_M_Employees");
        }
    }
}
