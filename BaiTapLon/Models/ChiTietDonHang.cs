using System.ComponentModel.DataAnnotations;

namespace BaiTapLon.Models
{
    public class ChiTietDonHang
    {
        [Key]
        public int ID { get; set; }
        public int DonHangID { get; set; }
        public int PetID { get; set; }
        public DonHang? DonHangs { get;set; }
        public Pet Pets { get; set; }    

    }
}
