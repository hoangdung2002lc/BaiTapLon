using BaiTapLon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon.Controllers
{
    public class GioHangController : Controller
    {
        private readonly PetDBcontext _context;

        public GioHangController(PetDBcontext context)
        {
            _context = context;
        }
        // GET: GioHangController
        public ActionResult Index()
        {
            var taikhoan = HttpContext.Session.GetString("taikhoan");
            if (taikhoan == null)
            {
                return RedirectToAction("LoginRegister", "Home");
            }
            else
            {
                var nguoidung = _context.NguoiDungs.FirstOrDefault(m => m.TaiKhoan == taikhoan);
                var ListGioHang = _context.GioHangs.Include(m => m.Pet).Where(m => m.NguoiDungID == nguoidung.ID).ToList();

                return View(ListGioHang);
            }
        }

        // GET: GioHangController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create(int id, string type = "Normal")
        {
            GioHang gioHang = new GioHang();
            var taikhoan = HttpContext.Session.GetString("taikhoan");
            if (taikhoan == null)
            {
                return View();
            }
            else
            {
                var nguoidung = _context.NguoiDungs.FirstOrDefault(m => m.TaiKhoan == taikhoan);

                
                gioHang.NguoiDungID = nguoidung.ID;
                gioHang.PetID = id;

                _context.GioHangs.Add(gioHang);
                _context.SaveChanges();
                if (type == "ajax")
                {
                    return Json(gioHang.ID);
                }
            }    
            return View();
        }

        // GET: GioHangController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GioHangController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GioHangController/Delete/5
        public ActionResult Delete(int id)
        {   
            var item = _context.GioHangs.Find(id);
            _context.GioHangs.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var taikhoan = HttpContext.Session.GetString("taikhoan");
            var nguoidung = _context.NguoiDungs.FirstOrDefault(m => m.TaiKhoan == taikhoan);
            var ListGioHang = _context.GioHangs.Include(m => m.Pet).Where(m => m.NguoiDungID == nguoidung.ID).ToList();
            ViewBag.IDNguoiDung = nguoidung.ID;
            return View(ListGioHang);
        }

        public IActionResult CheckoutCheck(int NguoiDungID, string TenKhachHang, string DiaChi, string SoDienThoai ,string type = "Normal")
        {
            if (TenKhachHang != null)
            {

                DonHang donHang = new DonHang();
                donHang.TenKhachHang = TenKhachHang;
                donHang.DiaChi = DiaChi;
                donHang.SoDienThoai = SoDienThoai;
                donHang.NguoiDungID = NguoiDungID;
                donHang.NgayDat = DateTime.Now;
                _context.DonHangs.Add(donHang);
                _context.SaveChanges();

                var donHangMoi = _context.DonHangs.OrderByDescending(m => m.ID).FirstOrDefault();
                var listHang = _context.GioHangs.Include(m => m.Pet).Where(m => m.NguoiDungID == NguoiDungID);

                foreach (var i in listHang)
                {
                    ChiTietDonHang chiTietDonHang = new ChiTietDonHang();
                    chiTietDonHang.DonHangID = donHangMoi.ID;
                    chiTietDonHang.PetID = i.Pet.ID;
                    _context.chiTietDonHangs.Add(chiTietDonHang);
                }

                _context.GioHangs.RemoveRange(listHang);
                _context.SaveChanges();
            }
            else
            {
                return View();
            }
            if (type == "ajax")
            {
                return Json(NguoiDungID);
            }
            return View();
        }
        
    }
}
