using System.ComponentModel.DataAnnotations;

namespace BaiTapLon.Models
{
    public class DonHang
    {
        [Key]
        public int ID { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayDat { get; set; }
        public int NguoiDungID { get; set; }
        public NguoiDung? NguoiDungs { get; set; }


    }
}
