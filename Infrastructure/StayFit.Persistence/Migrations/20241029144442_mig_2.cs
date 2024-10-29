using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Members_StudentId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionType",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Subscriptions",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_StudentId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_MemberId");

            migrationBuilder.AlterColumn<string>(
                name: "Specializations",
                table: "Trainers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Members_MemberId",
                table: "Subscriptions",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Members_MemberId",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Subscriptions",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_MemberId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_StudentId");

            migrationBuilder.AlterColumn<string>(
                name: "Specializations",
                table: "Trainers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionType",
                table: "Subscriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Members_StudentId",
                table: "Subscriptions",
                column: "StudentId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
