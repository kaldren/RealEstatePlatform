using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REP.Modules.Listings.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PriceCurrencyLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Listings",
                newName: "ZipCode");

            migrationBuilder.AlterColumn<string>(
                name: "ShortUrl",
                table: "Listings",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceAmount",
                table: "Listings",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceCurrencyCode",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceCurrencySymbol",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "PriceAmount",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "PriceCurrencyCode",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "PriceCurrencySymbol",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Listings",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "ShortUrl",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Listings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
