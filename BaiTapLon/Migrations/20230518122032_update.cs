using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLon.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "tbNguoiDung");

            migrationBuilder.DropColumn(
                name: "KhachHang",
                table: "tbNguoiDung");

            migrationBuilder.AddColumn<int>(
                name: "ChucVu",
                table: "tbNguoiDung",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChucVu",
                table: "tbNguoiDung");

            migrationBuilder.AddColumn<int>(
                name: "Admin",
                table: "tbNguoiDung",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KhachHang",
                table: "tbNguoiDung",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
