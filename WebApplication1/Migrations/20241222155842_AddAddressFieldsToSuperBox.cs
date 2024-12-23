using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressFieldsToSuperBox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "SuperBoxes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "SuperBoxes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "SuperBoxes",
                type: "TEXT",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "SuperBoxes",
                type: "TEXT",
                nullable: true); // Adăugăm ZipCode

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "SuperBoxes");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "SuperBoxes");

            migrationBuilder.DropColumn(
                name: "City",
                table: "SuperBoxes");

            migrationBuilder.DropColumn(
                name: "ZipCode", // Ștergem ZipCode la Down
                table: "SuperBoxes");

        }
    }
}
