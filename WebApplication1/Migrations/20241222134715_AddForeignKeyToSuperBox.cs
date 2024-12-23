using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddForeignKeyToSuperBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adăugăm cheia externă între SuperBox și Address
            migrationBuilder.AddForeignKey(
                name: "FK_SuperBoxes_Addresses_AddressId",  // Numele cheii externe
                table: "SuperBoxes",  // Tabela care conține cheia externă
                column: "AddressId",  // Coloana din SuperBoxes care va deveni cheia externă
                principalTable: "Addresses",  // Tabela principală
                principalColumn: "Id",  // Coloana principală la care se face referința
                onDelete: ReferentialAction.Cascade);  // Ce se întâmplă când un Address este șters
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Înlăturăm cheia externă dacă migrarea este inversată
            migrationBuilder.DropForeignKey(
                name: "FK_SuperBoxes_Addresses_AddressId",
                table: "SuperBoxes");
        }
    }
}