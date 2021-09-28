using Microsoft.EntityFrameworkCore.Migrations;

namespace AboneYonetim.WebAPI.Migrations
{
    public partial class dokuz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR");

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR",
                column: "FaturaID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR");

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR",
                column: "FaturaID");
        }
    }
}
