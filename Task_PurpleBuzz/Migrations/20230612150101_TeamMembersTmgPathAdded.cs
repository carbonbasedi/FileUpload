using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_PurpleBuzz.Migrations
{
    /// <inheritdoc />
    public partial class TeamMembersTmgPathAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "TeamMembers");
        }
    }
}
