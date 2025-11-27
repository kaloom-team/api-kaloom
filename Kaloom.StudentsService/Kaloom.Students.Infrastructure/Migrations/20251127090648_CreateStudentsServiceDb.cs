using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kaloom.Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateStudentsServiceDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Etecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeUnidade = table.Column<string>(type: "varchar(60)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etecs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fatecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeUnidade = table.Column<string>(type: "varchar(60)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatecs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoAlunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fatec = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Etec = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StatusEtec = table.Column<int>(type: "int", nullable: true),
                    StatusFatec = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(35)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAlunos", x => x.Id);
                    table.CheckConstraint("CK_StudentType_StatusEtec", "StatusEtec IN (1,2)");
                    table.CheckConstraint("CK_StudentType_StatusFatec", "StatusFatec IN (1,2)");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(16)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sobrenome = table.Column<string>(type: "varchar(24)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeUsuario = table.Column<string>(type: "varchar(24)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FotoPerfil = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTipoAluno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_TipoAlunos_IdTipoAluno",
                        column: x => x.IdTipoAluno,
                        principalTable: "TipoAlunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Etecs",
                columns: new[] { "Id", "NomeUnidade" },
                values: new object[,]
                {
                    { 1, "Etec JK - Sede" },
                    { 2, "Etec JK - Extensão Céu Caminho do Mar" },
                    { 3, "Etec JK - Extensão Associação Comunitária Despertar" },
                    { 4, "Etec Lauro Gomes" },
                    { 5, "Etec Jorge Street" }
                });

            migrationBuilder.InsertData(
                table: "Fatecs",
                columns: new[] { "Id", "NomeUnidade" },
                values: new object[,]
                {
                    { 1, "Fatec Diadema - \"Luigi Papaiz\"" },
                    { 2, "Fatec SBC - \"Adib Moisés Dib\"" },
                    { 3, "Fatec São Paulo" }
                });

            migrationBuilder.InsertData(
                table: "TipoAlunos",
                columns: new[] { "Id", "Description", "Etec", "Fatec", "StatusEtec", "StatusFatec" },
                values: new object[,]
                {
                    { 1, "Aluno Fatec", false, true, null, 1 },
                    { 2, "Ex-Aluno Fatec", false, true, null, 2 },
                    { 3, "Aluno Etec", true, false, 1, null },
                    { 4, "Ex-Aluno Etec", true, false, 2, null },
                    { 5, "Aluno Fatec e Etec", true, true, 1, 1 },
                    { 6, "Aluno Fatec e Ex-Aluno Etec", true, true, 2, 1 },
                    { 7, "Aluno Etec e Ex-Aluno Fatec", true, true, 1, 2 },
                    { 8, "Ex-Aluno Fatec e Ex-Aluno Etec", true, true, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdTipoAluno",
                table: "Alunos",
                column: "IdTipoAluno");

            migrationBuilder.CreateIndex(
                name: "IX_TipoAlunos_Fatec_Etec_StatusFatec_StatusEtec",
                table: "TipoAlunos",
                columns: new[] { "Fatec", "Etec", "StatusFatec", "StatusEtec" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Etecs");

            migrationBuilder.DropTable(
                name: "Fatecs");

            migrationBuilder.DropTable(
                name: "TipoAlunos");
        }
    }
}
