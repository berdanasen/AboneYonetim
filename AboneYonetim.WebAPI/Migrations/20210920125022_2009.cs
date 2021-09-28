using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AboneYonetim.WebAPI.Migrations
{
    public partial class _2009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ABONELER_KULLANICILAR_KullaniciID",
                table: "ABONELER");

            migrationBuilder.DropForeignKey(
                name: "FK_FATURALAR_KULLANICILAR_KullaniciID",
                table: "FATURALAR");

            migrationBuilder.DropTable(
                name: "TAHSILAT_DETAYLAR");

            migrationBuilder.DropIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR");

            migrationBuilder.DropIndex(
                name: "IX_FATURALAR_KullaniciID",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "ToplamTutar",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "FaturaNo",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "KullaniciID",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "Tutar",
                table: "FATURALAR");

            migrationBuilder.RenameColumn(
                name: "TahsilatTarihi",
                table: "TAHSILATLAR",
                newName: "TahTarhi");

            migrationBuilder.RenameColumn(
                name: "SonOdemeTarihi",
                table: "FATURALAR",
                newName: "FaturaSonOdemeTarih");

            migrationBuilder.RenameColumn(
                name: "Odendi",
                table: "FATURALAR",
                newName: "FaturaOdendiMi");

            migrationBuilder.RenameColumn(
                name: "FaturaTarihi",
                table: "FATURALAR",
                newName: "FaturaDuzenlenmeTarih");

            migrationBuilder.RenameColumn(
                name: "KullaniciID",
                table: "ABONELER",
                newName: "KulID");

            migrationBuilder.RenameIndex(
                name: "IX_ABONELER_KullaniciID",
                table: "ABONELER",
                newName: "IX_ABONELER_KulID");

            migrationBuilder.AddColumn<decimal>(
                name: "TahTutar",
                table: "TAHSILATLAR",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FaturaTutari",
                table: "FATURALAR",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AdSoyad",
                table: "ABONELER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Eposta",
                table: "ABONELER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TcKimlikNO",
                table: "ABONELER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonNo",
                table: "ABONELER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR",
                column: "FaturaID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ABONELER_KULLANICILAR_KulID",
                table: "ABONELER",
                column: "KulID",
                principalTable: "KULLANICILAR",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ABONELER_KULLANICILAR_KulID",
                table: "ABONELER");

            migrationBuilder.DropIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "TahTutar",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "FaturaTutari",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "AdSoyad",
                table: "ABONELER");

            migrationBuilder.DropColumn(
                name: "Eposta",
                table: "ABONELER");

            migrationBuilder.DropColumn(
                name: "TcKimlikNO",
                table: "ABONELER");

            migrationBuilder.DropColumn(
                name: "TelefonNo",
                table: "ABONELER");

            migrationBuilder.RenameColumn(
                name: "TahTarhi",
                table: "TAHSILATLAR",
                newName: "TahsilatTarihi");

            migrationBuilder.RenameColumn(
                name: "FaturaSonOdemeTarih",
                table: "FATURALAR",
                newName: "SonOdemeTarihi");

            migrationBuilder.RenameColumn(
                name: "FaturaOdendiMi",
                table: "FATURALAR",
                newName: "Odendi");

            migrationBuilder.RenameColumn(
                name: "FaturaDuzenlenmeTarih",
                table: "FATURALAR",
                newName: "FaturaTarihi");

            migrationBuilder.RenameColumn(
                name: "KulID",
                table: "ABONELER",
                newName: "KullaniciID");

            migrationBuilder.RenameIndex(
                name: "IX_ABONELER_KulID",
                table: "ABONELER",
                newName: "IX_ABONELER_KullaniciID");

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamTutar",
                table: "TAHSILATLAR",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FaturaNo",
                table: "FATURALAR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciID",
                table: "FATURALAR",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Tutar",
                table: "FATURALAR",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "TAHSILAT_DETAYLAR",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Du_KullaniciID = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    DuzeltmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FaturaID = table.Column<int>(type: "int", nullable: false),
                    Ka_KullaniciID = table.Column<int>(type: "int", nullable: true),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OdendiMi = table.Column<bool>(type: "bit", nullable: false),
                    Sil_KullaniciID = table.Column<int>(type: "int", nullable: true),
                    SilmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TahsilatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAHSILAT_DETAYLAR", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_TAHSILAT_DETAYLAR_FATURALAR_FaturaID",
                        column: x => x.FaturaID,
                        principalTable: "FATURALAR",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAHSILAT_DETAYLAR_TAHSILATLAR_TahsilatID",
                        column: x => x.TahsilatID,
                        principalTable: "TAHSILATLAR",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR",
                column: "FaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_FATURALAR_KullaniciID",
                table: "FATURALAR",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILAT_DETAYLAR_FaturaID",
                table: "TAHSILAT_DETAYLAR",
                column: "FaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILAT_DETAYLAR_TahsilatID",
                table: "TAHSILAT_DETAYLAR",
                column: "TahsilatID");

            migrationBuilder.AddForeignKey(
                name: "FK_ABONELER_KULLANICILAR_KullaniciID",
                table: "ABONELER",
                column: "KullaniciID",
                principalTable: "KULLANICILAR",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FATURALAR_KULLANICILAR_KullaniciID",
                table: "FATURALAR",
                column: "KullaniciID",
                principalTable: "KULLANICILAR",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
