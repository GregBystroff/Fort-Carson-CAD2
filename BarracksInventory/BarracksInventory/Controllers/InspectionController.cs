using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BarracksInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarracksInventory.Controllers
{
    public class InspectionController : Controller
    {

        // F i e l d s   &   P r o p e r t i e s 


        private IUnitRepository _repository;

        // C o n s t r u c t o r s 

        public InspectionController(IUnitRepository unitRepository)
        {
            _repository = unitRepository;
        }

        // M e t h o d s

        // C r e a t e

        [HttpGet]
        public IActionResult AddUnit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddUnit(Unit u)
        {
            if (ModelState.IsValid)
            {
                if (u.Password == u.ConfirmPassword)
                {
                    _repository.AddUnit(u);
                    RedirectToAction("UnitDetail", u.UnitId);
                    return View("UnitHome", u);
                }
                else
                {
                    return View(u);
                }
            }
            else
            {
                return View(u);
            }
        }


        // R e a d 

        public IActionResult Index(int id)
        {
            Unit unitId = _repository.GetUnitById(id);
            return View(unitId);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // U p d a t e

        [HttpGet]
        public IActionResult EditUnit()
        {
            // Go to database with id and get unit with that id.
            // This is a mock up DB.

            Unit u = new Unit
            {
                UnitId = 1,
                UnitName = "1st Military Police Company",
                RepName = "1LT Joe Snuffy",
                RepPhone = "123-456-7890",
                UnitAddress = "10005 Old IronSides Rd",
                City = "Fort Hood"
            };
            return View(u);
        }

        [HttpPost]
        public IActionResult EditAccount(Unit u)
        {
            if (ModelState.IsValid)
            {
                return View("UnitHome", u);
            }
            else
            {
                return View(u);
            }
        }


        // D e l e t e

        [HttpGet]
        public IActionResult DeleteUnit(int id)
        {
            Unit unit = _repository.GetUnitById(id);
            if (unit != null)
            {
                return View(unit);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUnit(Unit unit, int id)
        {
            _repository.DeleteUnitt(id);
            return RedirectToAction("Index");
        }


    }
}
