using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.ConsoleClient.Migrations
{
    public partial class AddWeightToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Products",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder
                .Sql("update Products set Weight = 100");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");
        }
    }
}
