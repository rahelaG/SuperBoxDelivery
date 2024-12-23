using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAddressIdFromSuperBox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crează tabela temporară ef_temp_SuperBoxes
            migrationBuilder.CreateTable(
                name: "ef_temp_SuperBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: true), // Permite NULL pentru City
                    StreetName = table.Column<string>(type: "TEXT", nullable: true), // Permite NULL pentru StreetName
                    StreetNumber = table.Column<int>(type: "INTEGER", nullable: true), // Permite NULL pentru StreetNumber
                    ZipCode = table.Column<int>(type: "INTEGER", nullable: true) // Permite NULL pentru ZipCode
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ef_temp_SuperBoxes", x => x.Id);
                });

            // Mută datele din tabela SuperBoxes în tabela temporară
            migrationBuilder.Sql("INSERT INTO ef_temp_SuperBoxes (Id, Capacity, City, StreetName, StreetNumber, ZipCode) SELECT Id, Capacity, City, StreetName, StreetNumber, ZipCode FROM SuperBoxes");

            // Șterge tabela originală SuperBoxes
            migrationBuilder.DropTable(
                name: "SuperBoxes");

            // Renumește tabela temporară în SuperBoxes
            migrationBuilder.RenameTable(
                name: "ef_temp_SuperBoxes",
                newName: "SuperBoxes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Dacă migrarea este inversată, procedăm la reconstruirea structurii originale
            migrationBuilder.RenameTable(
                name: "SuperBoxes",
                newName: "ef_temp_SuperBoxes");

            migrationBuilder.CreateTable(
                name: "SuperBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    StreetName = table.Column<string>(type: "TEXT", nullable: false),
                    StreetNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ZipCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperBoxes", x => x.Id);
                });

            // Mută datele înapoi din tabela temporară
            migrationBuilder.Sql("INSERT INTO SuperBoxes (Id, Capacity, City, StreetName, StreetNumber, ZipCode) SELECT Id, Capacity, City, StreetName, StreetNumber, ZipCode FROM ef_temp_SuperBoxes");

            // Șterge tabela temporară
            migrationBuilder.DropTable(name: "ef_temp_SuperBoxes");
        }
    }
}
