using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLon.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbDanhMuc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDanhMuc", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbNguoiDung",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<int>(type: "int", nullable: false),
                    KhachHang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbNguoiDung", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbPet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    ChieuCao = table.Column<double>(type: "float", nullable: false),
                    CanNang = table.Column<double>(type: "float", nullable: false),
                    MauLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanhMucID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbPet_tbDanhMuc_DanhMucID",
                        column: x => x.DanhMucID,
                        principalTable: "tbDanhMuc",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbDonHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiDungID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDonHang", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbDonHang_tbNguoiDung_NguoiDungID",
                        column: x => x.NguoiDungID,
                        principalTable: "tbNguoiDung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbChiTietDonHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonHangID = table.Column<int>(type: "int", nullable: false),
                    PetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbChiTietDonHang", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbChiTietDonHang_tbDonHang_DonHangID",
                        column: x => x.DonHangID,
                        principalTable: "tbDonHang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbChiTietDonHang_tbPet_PetID",
                        column: x => x.PetID,
                        principalTable: "tbPet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbChiTietDonHang_DonHangID",
                table: "tbChiTietDonHang",
                column: "DonHangID");

            migrationBuilder.CreateIndex(
                name: "IX_tbChiTietDonHang_PetID",
                table: "tbChiTietDonHang",
                column: "PetID");

            migrationBuilder.CreateIndex(
                name: "IX_tbDonHang_NguoiDungID",
                table: "tbDonHang",
                column: "NguoiDungID");

            migrationBuilder.CreateIndex(
                name: "IX_tbPet_DanhMucID",
                table: "tbPet",
                column: "DanhMucID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbChiTietDonHang");

            migrationBuilder.DropTable(
                name: "tbDonHang");

            migrationBuilder.DropTable(
                name: "tbPet");

            migrationBuilder.DropTable(
                name: "tbNguoiDung");

            migrationBuilder.DropTable(
                name: "tbDanhMuc");
        }
    }
}
