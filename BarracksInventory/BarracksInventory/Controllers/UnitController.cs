using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BarracksInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarracksInventory.Controllers
{
    public class UnitController : Controller
    {

        // F i e l d s   &   P r o p e r t i e s 


        private IUnitRepository _repository;

        // C o n s t r u c t o r s 

        public UnitController(IUnitRepository unitRepository)
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
                    _repository.AddUnit(u);
                    return RedirectToAction("UnitDetail", u);
                    // return View("UnitHome", u);
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


        public IActionResult Search(string phrase)
        {
            IQueryable<Unit> u = _repository.GetUnitByKeyword(phrase);
            return View(u);
        }

        public IActionResult Search(int unitId)
        {
            Unit u = _repository.GetUnitById(unitId);
            return View(u);
        }

        public IActionResult UnitDetail(Unit unit)
        {
            return View(unit);
        }

        // U p d a t e

        [HttpGet]
        public IActionResult EditUnit(int unitId)
        {
            Unit u = _repository.GetUnitById(unitId);

            if (u != null)
            {
                return View(u);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditUnit(Unit u)
        {
            Unit updatedUnit = _repository.EditUnit(u);
            if (updatedUnit == null)
            {
                return RedirectToAction("Index");
                // updatedProduct = _repository.GetProductById(1);
            }
            return RedirectToAction("ProductDetail", new { unitId = u.UnitId });
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
            _repository.DeleteUnit(id);
            return RedirectToAction("Index");
        }


    }
}
