using System.ComponentModel.DataAnnotations;

namespace BaiTapLon.Models
{
    public class GioHang
    {
        [Key]
        public int ID { get; set; }
        public int NguoiDungID { get; set; }
        public int PetID { get; set; }
        public NguoiDung? NguoiDung { get; set;}
        public Pet? Pet { get; set; }
    }
}
