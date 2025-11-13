using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kaloom.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_TipoAlunos_IdTipoAluno",
                table: "Alunos");

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Alunos",
                type: "varchar(24)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "NomeUsuario",
                table: "Alunos",
                type: "varchar(24)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "varchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FotoPerfil",
                table: "Alunos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Alunos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "TipoAlunos",
                columns: new[] { "Id", "Etec", "Fatec", "StatusEtec", "StatusFatec" },
                values: new object[,]
                {
                    { 1, false, true, null, 1 },
                    { 2, false, true, null, 2 },
                    { 3, true, false, 1, null },
                    { 4, true, false, 2, null },
                    { 5, true, true, 1, 1 },
                    { 6, true, true, 2, 1 },
                    { 7, true, true, 1, 2 },
                    { 8, true, true, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoAlunos_Fatec_Etec_StatusFatec_StatusEtec",
                table: "TipoAlunos",
                columns: new[] { "Fatec", "Etec", "StatusFatec", "StatusEtec" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_TipoAlunos_IdTipoAluno",
                table: "Alunos",
                column: "IdTipoAluno",
                principalTable: "TipoAlunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_TipoAlunos_IdTipoAluno",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_TipoAlunos_Fatec_Etec_StatusFatec_StatusEtec",
                table: "TipoAlunos");

            migrationBuilder.DeleteData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TipoAlunos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Alunos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(24)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "NomeUsuario",
                table: "Alunos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(24)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "FotoPerfil",
                keyValue: null,
                column: "FotoPerfil",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FotoPerfil",
                table: "Alunos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Alunos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_TipoAlunos_IdTipoAluno",
                table: "Alunos",
                column: "IdTipoAluno",
                principalTable: "TipoAlunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
