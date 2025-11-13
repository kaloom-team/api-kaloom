using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kaloom.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentTypeDescriptionProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TipoAlunos",
                type: "varchar(35)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TipoAlunos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(35)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
