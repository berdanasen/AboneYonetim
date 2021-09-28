using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AboneYonetim.WebAPI.Migrations
{
    public partial class seki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TahTarhi",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "TahTutar",
                table: "TAHSILATLAR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TahTarhi",
                table: "TAHSILATLAR",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TahTutar",
                table: "TAHSILATLAR",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
