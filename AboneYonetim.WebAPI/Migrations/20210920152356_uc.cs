using Microsoft.EntityFrameworkCore.Migrations;

namespace AboneYonetim.WebAPI.Migrations
{
    public partial class uc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaturaNo",
                table: "FATURALAR",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaturaNo",
                table: "FATURALAR");
        }
    }
}
