using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_PurpleBuzz.Migrations
{
    /// <inheritdoc />
    public partial class HomeSliderAndHomeSliderInfoModified_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "HomeSliders",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "HomeSliderInfos",
                newName: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "HomeSliders",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "HomeSliderInfos",
                newName: "IsActive");
        }
    }
}
