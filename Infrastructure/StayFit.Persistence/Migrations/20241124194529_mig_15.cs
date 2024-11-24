using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeeklyProgresses_SubscriptionId",
                table: "WeeklyProgresses");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyProgresses_SubscriptionId",
                table: "WeeklyProgresses",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeeklyProgresses_SubscriptionId",
                table: "WeeklyProgresses");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyProgresses_SubscriptionId",
                table: "WeeklyProgresses",
                column: "SubscriptionId",
                unique: true);
        }
    }
}
