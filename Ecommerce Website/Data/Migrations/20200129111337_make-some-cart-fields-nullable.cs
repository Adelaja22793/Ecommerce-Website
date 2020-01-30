using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce_Website.Data.Migrations
{
    public partial class makesomecartfieldsnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Addresses_SelectedAddressId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Colours_SelectedColourId",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedColourId",
                table: "Carts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SelectedAddressId",
                table: "Carts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Addresses_SelectedAddressId",
                table: "Carts",
                column: "SelectedAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Colours_SelectedColourId",
                table: "Carts",
                column: "SelectedColourId",
                principalTable: "Colours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Addresses_SelectedAddressId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Colours_SelectedColourId",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedColourId",
                table: "Carts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SelectedAddressId",
                table: "Carts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Addresses_SelectedAddressId",
                table: "Carts",
                column: "SelectedAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Colours_SelectedColourId",
                table: "Carts",
                column: "SelectedColourId",
                principalTable: "Colours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
