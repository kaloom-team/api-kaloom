using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kaloom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SituacaoAcademica",
                table: "TipoAlunos");

            migrationBuilder.AddColumn<int>(
                name: "StatusEtec",
                table: "TipoAlunos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusFatec",
                table: "TipoAlunos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataNascimento",
                table: "Alunos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Alunos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusEtec",
                table: "TipoAlunos");

            migrationBuilder.DropColumn(
                name: "StatusFatec",
                table: "TipoAlunos");

            migrationBuilder.AddColumn<int>(
                name: "SituacaoAcademica",
                table: "TipoAlunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Alunos",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Alunos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
