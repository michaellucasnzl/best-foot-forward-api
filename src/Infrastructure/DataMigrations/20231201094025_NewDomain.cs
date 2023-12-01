using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestFootForwardApi.Infrastructure.DataMigrations
{
    /// <inheritdoc />
    public partial class NewDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturer_Address_AddressId",
                table: "Manufacturer");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Manufacturer_ManufacturerId",
                table: "Shoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer");

            migrationBuilder.RenameTable(
                name: "Manufacturer",
                newName: "Manufacturers");

            migrationBuilder.RenameIndex(
                name: "IX_Manufacturer_AddressId",
                table: "Manufacturers",
                newName: "IX_Manufacturers_AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shoes",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Address_AddressId",
                table: "Manufacturers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Manufacturers_ManufacturerId",
                table: "Shoes",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Address_AddressId",
                table: "Manufacturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Manufacturers_ManufacturerId",
                table: "Shoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers");

            migrationBuilder.RenameTable(
                name: "Manufacturers",
                newName: "Manufacturer");

            migrationBuilder.RenameIndex(
                name: "IX_Manufacturers_AddressId",
                table: "Manufacturer",
                newName: "IX_Manufacturer_AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shoes",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturer_Address_AddressId",
                table: "Manufacturer",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Manufacturer_ManufacturerId",
                table: "Shoes",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
