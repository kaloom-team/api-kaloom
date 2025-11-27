using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kaloom.Students.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fatecs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fatecs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fatecs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "NomeUnidade",
                table: "Fatecs");

            migrationBuilder.DropColumn(
                name: "NomeUnidade",
                table: "Etecs");

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Fatecs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Etecs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeUnidade = table.Column<string>(type: "varchar(60)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlunoInstituicoes",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    InstituicoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoInstituicoes", x => new { x.AlunosId, x.InstituicoesId });
                    table.ForeignKey(
                        name: "FK_AlunoInstituicoes_Alunos_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoInstituicoes_Instituicao_InstituicoesId",
                        column: x => x.InstituicoesId,
                        principalTable: "Instituicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Instituicao",
                columns: new[] { "Id", "NomeUnidade" },
                values: new object[,]
                {
                    { 1, "Etec JK - Sede" },
                    { 2, "Etec JK - Extensão Céu Caminho do Mar" },
                    { 3, "Etec JK - Extensão Associação Comunitária Despertar" },
                    { 4, "Etec Lauro Gomes" },
                    { 5, "Etec Jorge Street" },
                    { 6, "Fatec Diadema - \"Luigi Papaiz\"" },
                    { 7, "Fatec SBC - \"Adib Moisés Dib\"" },
                    { 8, "Fatec São Paulo" }
                });

            migrationBuilder.InsertData(
                table: "Fatecs",
                column: "Id",
                values: new object[]
                {
                    6,
                    7,
                    8
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoInstituicoes_InstituicoesId",
                table: "AlunoInstituicoes",
                column: "InstituicoesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etecs_Instituicao_Id",
                table: "Etecs",
                column: "Id",
                principalTable: "Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fatecs_Instituicao_Id",
                table: "Fatecs",
                column: "Id",
                principalTable: "Instituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etecs_Instituicao_Id",
                table: "Etecs");

            migrationBuilder.DropForeignKey(
                name: "FK_Fatecs_Instituicao_Id",
                table: "Fatecs");

            migrationBuilder.DropTable(
                name: "AlunoInstituicoes");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DeleteData(
                table: "Fatecs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fatecs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Fatecs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Fatecs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "NomeUnidade",
                table: "Fatecs",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Etecs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "NomeUnidade",
                table: "Etecs",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Alunos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "Alunos",
                type: "varchar(24)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Etecs",
                keyColumn: "Id",
                keyValue: 1,
                column: "NomeUnidade",
                value: "Etec JK - Sede");

            migrationBuilder.UpdateData(
                table: "Etecs",
                keyColumn: "Id",
                keyValue: 2,
                column: "NomeUnidade",
                value: "Etec JK - Extensão Céu Caminho do Mar");

            migrationBuilder.UpdateData(
                table: "Etecs",
                keyColumn: "Id",
                keyValue: 3,
                column: "NomeUnidade",
                value: "Etec JK - Extensão Associação Comunitária Despertar");

            migrationBuilder.UpdateData(
                table: "Etecs",
                keyColumn: "Id",
                keyValue: 4,
                column: "NomeUnidade",
                value: "Etec Lauro Gomes");

            migrationBuilder.UpdateData(
                table: "Etecs",
                keyColumn: "Id",
                keyValue: 5,
                column: "NomeUnidade",
                value: "Etec Jorge Street");

            migrationBuilder.InsertData(
                table: "Fatecs",
                columns: new[] { "Id", "NomeUnidade" },
                values: new object[,]
                {
                    { 1, "Fatec Diadema - \"Luigi Papaiz\"" },
                    { 2, "Fatec SBC - \"Adib Moisés Dib\"" },
                    { 3, "Fatec São Paulo" }
                });
        }
    }
}
