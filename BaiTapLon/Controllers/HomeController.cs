using BaiTapLon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace BaiTapLon.Controllers
{
    public class HomeController : BaseController
    {
		private readonly PetDBcontext _context;

		public HomeController(PetDBcontext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ThongTin()
        {
            return View();
        }
        public IActionResult DichVu()
        {
            return View();
        }
        public IActionResult SanPham()
        {
            var listPets = (from p in _context.Pets select p).ToList();
            return View(listPets);
        }
        [HttpGet]
        public IActionResult LoginRegister() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(String taikhoan, String matkhau)
        {
            var check = from n in _context.NguoiDungs where n.TaiKhoan == taikhoan && n.MatKhau == matkhau select n;
                Console.WriteLine(check);
            if (!check.IsNullOrEmpty())
            {
                HttpContext.Session.SetString("taikhoan", taikhoan);
                var user = _context.NguoiDungs.Where(m => m.TaiKhoan == taikhoan && m.MatKhau == matkhau).FirstOrDefault();
                if (user.ChucVu == 1)
                {
                    return RedirectToAction("QuanLyPet", "NguoiDung");
                }
                else
                {
                    return RedirectToAction("Index", "Pets");
                }
            }
            else
            {
                return RedirectToAction("LoginRegister", "Home");
            }
            
		}
        [HttpPost]
        public IActionResult SignUp([Bind("TaiKhoan", "MatKhau")] NguoiDung nguoiDung)
        {
            _context.NguoiDungs.Add(nguoiDung);
            _context.SaveChanges();
            return RedirectToAction("LoginRegister");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("taikhoan");
            return RedirectToAction("Index","Pets");
        }


    }
}