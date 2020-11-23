using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BarracksInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarracksInventory.Controllers
{
    public class InventoryController : Controller
    {
        // F i e l d s   &    P r o p e r t i e s

        private readonly ILogger<InventoryController> _logger;

        private IInventoryRepository _repository;


        // C o n t r o l l e r s 
        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        // M e t h o d s

        // C r e a t e

        [HttpGet]
        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            if (ModelState.IsValid)
            {
                    _repository.AddItem(item);
                    RedirectToAction("AddItem", item.itemId);
                    return View("UserHome", item);
            }
            else
            {
                return View(item);
            }
        }


        // R e a d

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        // U p d a t e

        public IActionResult EditAccount()
        {
            // Go to database with id and get account with that id.
            // This is a mock up DB.

            Item item = new Item
            {
                ItemId = 1,
                UserId = 1,
                ItemName = "Lamp",
                Qty = 1,
                Price = 19.95M,
            };
            return View(item);
        }

        [HttpPost]
        public IActionResult EditAccount(Item item)
        {
            if (ModelState.IsValid)
            {
                return View("AddItem", item);
            }
            else
            {
                return View(item);
            }
        }


        // D e l e t e

        [HttpGet]
        public IActionResult DeleteAccount(int id)
        {
            Item item = _repository.GetItemById(id);
            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("UserHome");
        }

        [HttpPost]
        public IActionResult DeleteAccount(Item item, int id)
        {
            _repository.DeleteItem(id);
            return RedirectToAction("UserHome");
        }
    }
}
