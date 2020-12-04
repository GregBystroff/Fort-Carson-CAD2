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


        private IInspectionRepository _repository;

        // C o n s t r u c t o r s 

        public InspectionController(IInspectionRepository inspectionRepository)
        {
            _repository = inspectionRepository;
        }


        // M e t h o d s

        // C r e a t e

        [HttpGet]
        public IActionResult AddInspection()
        {
            return View();
        }
        // Back, Submit buttons

        [HttpPost]
        public IActionResult AddInspection(Inspection insp)
        {
            if (ModelState.IsValid)
            {
                    _repository.AddInspection(insp);
                    return RedirectToAction("InspectionDetails", insp.InspectionId);
                    // return View("UnitHome", insp);
            }
            else
            {
                return View(insp);
            }
        }


        // R e a d 

        public IActionResult InspectionDetails(int id)
        {
            Inspection inspId = _repository.GetInspectionById(id);
            return View(inspId);
        }
        // ID passed in through "Unit Inspections" view. Shows all details for that inspection.

        public IActionResult GetInspectionByUnit(Unit u)
        {
            IQueryable<Inspection> inspections = _repository.GetAccountInspections(u);
            return View(inspections);
        }


        // U p d a t e


        // D e l e t e



    }
}
