using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AboneYonetim.WebAPI.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KULLANICI_ROLLER",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_KULLANICI_ROLLER", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "KULLANICILAR",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolID = table.Column<int>(type: "int", nullable: true),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GsmNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Kulad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_KULLANICILAR", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_KULLANICILAR_KULLANICI_ROLLER_RolID",
                        column: x => x.RolID,
                        principalTable: "KULLANICI_ROLLER",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ABONELER",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    AboneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ABONELER", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_ABONELER_KULLANICILAR_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "KULLANICILAR",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FATURALAR",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboneID = table.Column<int>(type: "int", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    FaturaDonemi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonOdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Odendi = table.Column<bool>(type: "bit", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_FATURALAR", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_FATURALAR_ABONELER_AboneID",
                        column: x => x.AboneID,
                        principalTable: "ABONELER",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FATURALAR_KULLANICILAR_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "KULLANICILAR",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TAHSILATLAR",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboneID = table.Column<int>(type: "int", nullable: false),
                    FaturaID = table.Column<int>(type: "int", nullable: false),
                    TahsilatTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_TAHSILATLAR", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_TAHSILATLAR_ABONELER_AboneID",
                        column: x => x.AboneID,
                        principalTable: "ABONELER",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAHSILATLAR_FATURALAR_FaturaID",
                        column: x => x.FaturaID,
                        principalTable: "FATURALAR",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TAHSILAT_DETAYLAR",
                columns: table => new
                {
                    ObjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TahsilatID = table.Column<int>(type: "int", nullable: false),
                    FaturaID = table.Column<int>(type: "int", nullable: false),
                    OdendiMi = table.Column<bool>(type: "bit", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ABONELER_KullaniciID",
                table: "ABONELER",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_FATURALAR_AboneID",
                table: "FATURALAR",
                column: "AboneID");

            migrationBuilder.CreateIndex(
                name: "IX_FATURALAR_KullaniciID",
                table: "FATURALAR",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_KULLANICILAR_RolID",
                table: "KULLANICILAR",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILAT_DETAYLAR_FaturaID",
                table: "TAHSILAT_DETAYLAR",
                column: "FaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILAT_DETAYLAR_TahsilatID",
                table: "TAHSILAT_DETAYLAR",
                column: "TahsilatID");

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILATLAR_AboneID",
                table: "TAHSILATLAR",
                column: "AboneID");

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR",
                column: "FaturaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAHSILAT_DETAYLAR");

            migrationBuilder.DropTable(
                name: "TAHSILATLAR");

            migrationBuilder.DropTable(
                name: "FATURALAR");

            migrationBuilder.DropTable(
                name: "ABONELER");

            migrationBuilder.DropTable(
                name: "KULLANICILAR");

            migrationBuilder.DropTable(
                name: "KULLANICI_ROLLER");
        }
    }
}
