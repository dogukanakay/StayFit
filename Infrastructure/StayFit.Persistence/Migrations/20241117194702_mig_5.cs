using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "WorkoutPlans",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "DietPlans",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_MemberId",
                table: "WorkoutPlans",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlans_MemberId",
                table: "DietPlans",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietPlans_Members_MemberId",
                table: "DietPlans",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_Members_MemberId",
                table: "WorkoutPlans",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietPlans_Members_MemberId",
                table: "DietPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_Members_MemberId",
                table: "WorkoutPlans");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutPlans_MemberId",
                table: "WorkoutPlans");

            migrationBuilder.DropIndex(
                name: "IX_DietPlans_MemberId",
                table: "DietPlans");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "WorkoutPlans");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "DietPlans");
        }
    }
}
