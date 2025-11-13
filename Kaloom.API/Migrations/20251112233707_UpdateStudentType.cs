using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kaloom.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TipoAlunos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Aluno Fatec");

            migrationBuilder.UpdateData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Ex-Aluno Fatec");

            migrationBuilder.UpdateData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Aluno Etec");

            migrationBuilder.UpdateData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Ex-Aluno Etec");

            migrationBuilder.UpdateData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Aluno Fatec e Etec");

            migrationBuilder.UpdateData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Aluno Fatec e Ex-Aluno Etec");

            migrationBuilder.UpdateData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Aluno Etec e Ex-Aluno Fatec");

            migrationBuilder.UpdateData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Ex-Aluno Fatec e Ex-Aluno Etec");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TipoAlunos");
        }
    }
}
