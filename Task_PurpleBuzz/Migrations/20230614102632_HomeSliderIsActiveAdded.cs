using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_PurpleBuzz.Migrations
{
    /// <inheritdoc />
    public partial class HomeSliderIsActiveAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HomeSliders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HomeSliders");
        }
    }
}
