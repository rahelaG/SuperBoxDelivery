using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Dezactivează temporar constrângerile FOREIGN KEY
            migrationBuilder.Sql("PRAGMA foreign_keys = 0;");

            // Opțional: Dacă există tabele care fac referință la Addresses, elimină sau actualizează referințele înainte de a șterge
            // Dacă există o coloană de tip ForeignKey, cum ar fi "AddressId", ar trebui să o actualizezi sau să o ștergi
            migrationBuilder.Sql("UPDATE SuperBoxes SET AddressId = NULL WHERE AddressId IS NOT NULL;"); // De exemplu, actualizezi referințele la NULL

            // Șterge tabelul "Addresses"
            migrationBuilder.DropTable(
                name: "Addresses");

            // Reactivați constrângerile FOREIGN KEY
            migrationBuilder.Sql("PRAGMA foreign_keys = 1;");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Poți adăuga comanda pentru a recrea tabelul Address, dacă este necesar
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });
        }
    }
}
