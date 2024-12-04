using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetTime",
                table: "Diets");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "DietDays",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "DietDays",
                newName: "Notes");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TargetTime",
                table: "Diets",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
