using Microsoft.EntityFrameworkCore.Migrations;

namespace CongTyBaoVe.Web.Migrations
{
    public partial class taobang2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "duongdan",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duongdan",
                table: "NhanVien");
        }
    }
}
