using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgressStatus",
                table: "WeeklyProgresses",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgressStatus",
                table: "WeeklyProgresses");
        }
    }
}
