using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Loginform.Controllers
{
    public class LogInController : Controller
    {
        //  
        // GET: /login/  
        static List<User> user = new List<User>();

        public ActionResult Index()
        {
            return View(sun);
        }
        public ActionResult Record(User u)
        {
            return View(u);
        }

        public ActionResult Login()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(User u)
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
