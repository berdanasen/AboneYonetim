using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AboneYonetim.WebAPI.Migrations
{
    public partial class on : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TahTarhi",
                table: "TAHSILATLAR",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TahTutar",
                table: "TAHSILATLAR",
                type: "decimal(18,4)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TahTarhi",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "TahTutar",
                table: "TAHSILATLAR");
        }
    }
}
