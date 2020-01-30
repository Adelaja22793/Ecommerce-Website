using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce_Website.Data.Migrations
{
    public partial class apicall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fbe10fa-62f7-4796-800c-daac319f1fc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9921fcb3-826f-4dee-b91a-47b7c70840c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3acaee3-c0eb-4a8e-8a1d-29709f2ab589", "80815dc2-e7e8-494d-9161-e182b07fb673", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "776cc395-9519-4392-a5a2-6bd55fffb7b9", "9b05e120-e773-4bf1-8935-105fe7a9b7e2", "Staff", "STAFF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "776cc395-9519-4392-a5a2-6bd55fffb7b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3acaee3-c0eb-4a8e-8a1d-29709f2ab589");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9921fcb3-826f-4dee-b91a-47b7c70840c0", "01277754-ec35-42b5-bb0f-52e5df138351", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fbe10fa-62f7-4796-800c-daac319f1fc2", "73002abe-bc01-4824-b428-4974e4811ef7", "Staff", "STAFF" });
        }
    }
}
