using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class DisableForeignKeyConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Dezactivează constrângerile de tip FOREIGN KEY
            migrationBuilder.Sql("PRAGMA foreign_keys = 0;");

            // Alte operațiuni de modificare a tabelelor, dacă sunt necesare
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Activează din nou constrângerile de tip FOREIGN KEY
            migrationBuilder.Sql("PRAGMA foreign_keys = 1;");
        }
    }
}