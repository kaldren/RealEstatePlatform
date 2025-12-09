using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REP.Modules.Listings.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Listings1292025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Listings",
                newName: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Listings",
                newName: "OwnerId");
        }
    }
}
