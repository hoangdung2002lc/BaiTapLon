using BaiTapLon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon.Controllers
{
    public class NguoiDungController : Controller
    {
		private readonly PetDBcontext _context;

		public NguoiDungController(PetDBcontext context)
		{
			_context = context;
		}
		// GET: NguoiDungController
		public ActionResult Index()
        {
            return View();
        }

        public IActionResult QuanLyPet()
        {
			var listPets = (from p in _context.Pets select p).ToList();
			return View(listPets);
		}

        //quản lý đơn hàng của admin
        public IActionResult QuanLyDonHang()
        {
            var listDonHangs = (from p in _context.DonHangs select p).ToList();
            return View(listDonHangs);
        }

        public IActionResult ChiTietDonHang(int id)
        {
            var listChiTiet = _context.chiTietDonHangs.Include(m => m.Pets).Where(m => m.DonHangID == id).ToList();
            return View(listChiTiet);
        }

        //đơn hàng của người dùng
        public IActionResult DonHang() 
        {
            var taikhoan = HttpContext.Session.GetString("taikhoan");
            var nguoidung = _context.NguoiDungs.FirstOrDefault(m => m.TaiKhoan == taikhoan);
            var listDonHang = _context.DonHangs.Where(m => m.NguoiDungID == nguoidung.ID).ToList();
            return View(listDonHang); 
        }

        //khách hàng xem chi tiết đơn hàng của mình
        public IActionResult XemChiTietDonHang(int id)
        {
            var listChiTiet = _context.chiTietDonHangs.Include(m => m.Pets).Where(m => m.DonHangID == id).ToList();
            return View(listChiTiet);
        }

        //Hủy đon hàng
        public IActionResult HuyDonHang(int id)
        {
            var chiTietDonHang = _context.chiTietDonHangs.Where(m => m.DonHangID == id).ToList();
            _context.RemoveRange(chiTietDonHang);

            var donHang = _context.DonHangs.Where(m => m.ID == id).FirstOrDefault();
            _context.Remove(donHang);
            _context.SaveChanges();
            return RedirectToAction("DonHang");
        }

    }
}
