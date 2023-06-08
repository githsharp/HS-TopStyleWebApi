using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HS_TopStyleWebApi.Repos.Migrations
{
    /// <inheritdoc />
    public partial class updateCategAzHSTopStyle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Categories",
                type: "int",
                nullable: true);
        }
    }
}
