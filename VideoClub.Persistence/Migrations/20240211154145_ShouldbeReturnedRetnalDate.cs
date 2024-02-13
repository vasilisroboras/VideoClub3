using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoClub.Persistence.Migrations
{
    public partial class ShouldbeReturnedRetnalDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShouldBeReturnedUntil",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShouldBeReturnedUntil",
                table: "Rentals");
        }
    }
}
