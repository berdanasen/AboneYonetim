using Microsoft.EntityFrameworkCore.Migrations;

namespace AboneYonetim.WebAPI.Migrations
{
    public partial class onbir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FATURALAR_ABONELER_AboneID",
                table: "FATURALAR");

            migrationBuilder.DropIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR");

            migrationBuilder.AlterColumn<int>(
                name: "AboneID",
                table: "FATURALAR",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TahsilatID",
                table: "FATURALAR",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR",
                column: "FaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_FATURALAR_TahsilatID",
                table: "FATURALAR",
                column: "TahsilatID");

            migrationBuilder.AddForeignKey(
                name: "FK_FATURALAR_ABONELER_AboneID",
                table: "FATURALAR",
                column: "AboneID",
                principalTable: "ABONELER",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FATURALAR_TAHSILATLAR_TahsilatID",
                table: "FATURALAR",
                column: "TahsilatID",
                principalTable: "TAHSILATLAR",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FATURALAR_ABONELER_AboneID",
                table: "FATURALAR");

            migrationBuilder.DropForeignKey(
                name: "FK_FATURALAR_TAHSILATLAR_TahsilatID",
                table: "FATURALAR");

            migrationBuilder.DropIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR");

            migrationBuilder.DropIndex(
                name: "IX_FATURALAR_TahsilatID",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "TahsilatID",
                table: "FATURALAR");

            migrationBuilder.AlterColumn<int>(
                name: "AboneID",
                table: "FATURALAR",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAHSILATLAR_FaturaID",
                table: "TAHSILATLAR",
                column: "FaturaID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FATURALAR_ABONELER_AboneID",
                table: "FATURALAR",
                column: "AboneID",
                principalTable: "ABONELER",
                principalColumn: "ObjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
