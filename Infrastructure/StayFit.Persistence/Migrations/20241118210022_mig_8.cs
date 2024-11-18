using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "DietDays");

            migrationBuilder.AddColumn<DateTime>(
                name: "Day",
                table: "DietDays",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "DietDays");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledDate",
                table: "Diets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "DietDays",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
