using Microsoft.EntityFrameworkCore.Migrations;

namespace AboneYonetim.WebAPI.Migrations
{
    public partial class ondort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "DonemID",
                table: "TAHSILATLAR",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILATLAR_DonemID",
                table: "TAHSILATLAR",
                column: "DonemID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAHSILATLAR_DONEMLER_DonemID",
                table: "TAHSILATLAR",
                column: "DonemID",
                principalTable: "DONEMLER",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAHSILATLAR_DONEMLER_DonemID",
                table: "TAHSILATLAR");

            migrationBuilder.DropIndex(
                name: "IX_TAHSILATLAR_DonemID",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "DonemID",
                table: "TAHSILATLAR");

            migrationBuilder.AddColumn<string>(
                name: "FaturaDonemi",
                table: "FATURALAR",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
