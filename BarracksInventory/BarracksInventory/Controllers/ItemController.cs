using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BarracksInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarracksInventory.Controllers
{
    public class ItemController : Controller
    {
        // F i e l d s   &    P r o p e r t i e s


        private IItemRepository _repository;


        // C o n t r o l l e r s 
        public ItemController(IItemRepository itemRepository)
        {
            _repository = itemRepository;
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

        public IActionResult Index(Account a)
        {
            IQueryable<Item> inventory = _repository.GetAccountItems(a);
            return View(inventory);
        }


        public IActionResult Search(string phrase)
        {
            IQueryable<Item> i = _repository.GetItemByKeyword(phrase);
            return View(i);
        }

        public IActionResult Search(int itemId)
        {
            Item i = _repository.GetItemById(itemId);
            return View(i);
        }


        // U p d a t e

        [HttpGet]
        public IActionResult EditItem(int itemId)
        {

            Item item = _repository.GetItemById(itemId);

            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditItem(Item item)
        {
            Item updatedItem = _repository.EditItem(item);
            if (updatedItem == null)
            {
                return RedirectToAction("Index");
                // updatedProduct = _repository.GetProductById(1);
            }
            return RedirectToAction("ProductDetail", new { itemId = item.ItemId });
        }


        // D e l e t e

        [HttpGet]
        public IActionResult DeleteItem(int id)
        {
            Item item = _repository.GetItemById(id);
            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("UserHome");
        }

        [HttpPost]
        public IActionResult DeleteItem(Item item, int id)
        {
            _repository.DeleteItem(id);
            return RedirectToAction("UserHome");
        }
    }
}
