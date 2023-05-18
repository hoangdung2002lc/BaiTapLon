using System.ComponentModel.DataAnnotations;

namespace BaiTapLon.Models
{
    public class NguoiDung
    {
        [Key]
        public int ID { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int ChucVu { get; set; }

    }
}
