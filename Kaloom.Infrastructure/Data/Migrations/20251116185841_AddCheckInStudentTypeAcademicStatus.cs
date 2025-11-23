using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kaloom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckInStudentTypeAcademicStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_StudentType_StatusEtec",
                table: "TipoAlunos",
                sql: "StatusEtec IN (1,2)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_StudentType_StatusFatec",
                table: "TipoAlunos",
                sql: "StatusFatec IN (1,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_StudentType_StatusEtec",
                table: "TipoAlunos");

            migrationBuilder.DropCheckConstraint(
                name: "CK_StudentType_StatusFatec",
                table: "TipoAlunos");
        }
    }
}
