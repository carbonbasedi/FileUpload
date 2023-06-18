using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_PurpleBuzz.Migrations
{
    /// <inheritdoc />
    public partial class WorkCategoryModified_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "WorkCategories");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "WorkCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WorkCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "WorkCategories",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "WorkCategories");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "WorkCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WorkCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "WorkCategories");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "WorkCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
