/*
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Loginform.Controllers
{
    public class LogInController : Controller
    {
        //  
        // GET: /login/  
        static List<User> user = new List<User>();

        public IActionResult Index()
        {
            return View(user);
        }
        public IActionResult Record(User u)
        {
            return View(u);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", u);
            }
            user.Add(u);
            return RedirectToAction("Index");
        }
    }
}
*/