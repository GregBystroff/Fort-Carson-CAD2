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


        [HttpPost]
        public IActionResult AddInspection(Inspection insp)
        {
            if (ModelState.IsValid)
            {
                if (insp.Password == insp.ConfirmPassword)
                {
                    _repository.AddInspection(insp);
                    RedirectToAction("UnitDetail", insp.UnitId);
                    return View("UnitHome", insp);
                }
                else
                {
                    return View(i);
                }
            }
            else
            {
                return View(i);
            }
        }


        // R e a d 

        public IActionResult Index(int id)
        {
            Inspection inspId = _repository.GetInspectionById(id);
            return View(inspId);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // U p d a t e


        // D e l e t e



    }
}
