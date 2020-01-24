using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce_Website.Data.Migrations
{
    public partial class addedbannerfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BannerImage",
                table: "SubCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerImage",
                table: "SubCategories");
        }
    }
}
