using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AboneYonetim.WebAPI.Migrations
{
    public partial class oniki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DonemID",
                table: "FATURALAR",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DONEMLER",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Donem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ka_KullaniciID = table.Column<int>(type: "int", nullable: true),
                    DuzeltmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Du_KullaniciID = table.Column<int>(type: "int", nullable: true),
                    SilmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sil_KullaniciID = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DONEMLER", x => x.ObjectID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FATURALAR_DonemID",
                table: "FATURALAR",
                column: "DonemID");

            migrationBuilder.AddForeignKey(
                name: "FK_FATURALAR_DONEMLER_DonemID",
                table: "FATURALAR",
                column: "DonemID",
                principalTable: "DONEMLER",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FATURALAR_DONEMLER_DonemID",
                table: "FATURALAR");

            migrationBuilder.DropTable(
                name: "DONEMLER");

            migrationBuilder.DropIndex(
                name: "IX_FATURALAR_DonemID",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "DonemID",
                table: "FATURALAR");
        }
    }
}
