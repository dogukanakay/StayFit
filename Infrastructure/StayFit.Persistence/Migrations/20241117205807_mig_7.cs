using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_TrainerId",
                table: "Subscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_TrainerId_PaymentStatus",
                table: "Subscriptions",
                columns: new[] { "TrainerId", "PaymentStatus" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_TrainerId_PaymentStatus",
                table: "Subscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_TrainerId",
                table: "Subscriptions",
                column: "TrainerId");
        }
    }
}
