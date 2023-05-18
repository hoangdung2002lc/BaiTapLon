using BaiTapLon.Models;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult LoginRegister() 
        {
            return View();
        }
        [HttpPost]
		public IActionResult Login(String taikhoan, String matkhau)
		{
			return Json(new {taikhoan,matkhau});
		}
        [HttpPost]
        public IActionResult SignUp()
        {
            return View();
        }
		public IActionResult Logout()
        {
            return View();

        }
        
    }
}