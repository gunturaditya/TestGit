using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStudy1.Migrations
{
    /// <inheritdoc />
    public partial class updateEntitasEducations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "gpa",
                table: "TB_M_Educations",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldMaxLength: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "gpa",
                table: "TB_M_Educations",
                type: "varchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");
        }
    }
}
