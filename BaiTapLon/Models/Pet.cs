using System.ComponentModel.DataAnnotations;

namespace BaiTapLon.Models
{
    public class Pet
    {
        [Key]
        public int ID { get; set; }
        public string TenPet { get; set; }
        public double Gia { get; set; }
        public double ChieuCao { get; set; }
        public double CanNang { get; set; }
        public string MauLong { get; set; }
        public string HinhAnh { get; set; }
        public int DanhMucID { get; set; }
        public DanhMuc? DanhMucs { get; set; }

    }
}
