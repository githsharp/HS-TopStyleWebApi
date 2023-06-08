using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HS_TopStyleWebApi.Repos.Migrations
{
    /// <inheritdoc />
    public partial class updateCntrlHSTopStyle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Categories",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Categories");
        }
    }
}
