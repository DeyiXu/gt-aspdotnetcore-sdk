using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Geetest.WebApp.Helper;

namespace Geetest.WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string name, string pass)
        {
            if (!GeetestHelper.ValidateCapthca(Request))
            {
                ModelState.AddModelError("", "—È÷§¬Î—È÷§ ß∞‹");
                return View();
            }
            if (name != "admin" || pass != "admin")
            {
                ModelState.AddModelError("", "’À∫≈ªÚ√‹¬Î¥ÌŒÛ");
            }
            
            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult GetCaptcha()
        {
            string str = GeetestHelper.GetCaptcha();
            return Content(str);
        }
    }
}