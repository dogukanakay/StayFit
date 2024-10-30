using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Members_MemberId",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Goals",
                newName: "SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_MemberId",
                table: "Goals",
                newName: "IX_Goals_SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Subscriptions_SubscriptionId",
                table: "Goals",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Subscriptions_SubscriptionId",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "Goals",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_SubscriptionId",
                table: "Goals",
                newName: "IX_Goals_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Members_MemberId",
                table: "Goals",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
