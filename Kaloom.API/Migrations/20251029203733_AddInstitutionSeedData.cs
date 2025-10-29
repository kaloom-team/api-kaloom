using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kaloom.API.Migrations
{
    /// <inheritdoc />
    public partial class AddInstitutionSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Etecs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Etecs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Etecs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Etecs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Etecs",
                keyColumn: "Id",
                keyValue: 5);

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
        }
    }
}
