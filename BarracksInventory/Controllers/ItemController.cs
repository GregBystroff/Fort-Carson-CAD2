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


        // C o n s t r u c t o r
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
        // View to show: AddItem
        // Form: Item Name, Qty, Price (opt), Description (opt)
        //Buttons: Back (ItemDetails), Submit (ItemDetails)


        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            if (ModelState.IsValid)
            {
                    _repository.AddItem(item);
                    RedirectToAction("AddItem", item.ItemId);
                    return View("UserHome", item);
            }
            else
            {
                return View(item);
            }
        }


        // R e a d

        public IActionResult ItemDetails(Account a)
        {
            IQueryable<Item> inventory = _repository.GetAccountItems(a);
            return View("ItemDetails", inventory);
        }
        // View to show: ItemDetails
        // Buttons: Back (HomePage), Add Item (AddItem), Edit Item (EditItem), 
        //          Delete Item (DeleteItem), Search Item (SearchItem)

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
        // Search pending implementation.  Not used yet.


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
        // View to show: EditItem
        // Form: Item Name, Qty, Price (opt), Description (opt)
        // Buttons: Cancel (ItemDetails), Submit (ItemDetails)


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
        // View to show: DeleteItem
        // Confirmation Bubble, Show details of that item
        // Buttons: Cancel (ItemDetails), Commit (ItemDetails


        [HttpPost]
        public IActionResult DeleteItem(Item item, int id)
        {
            _repository.DeleteItem(id);
            return RedirectToAction("UserHome");
        }
    }
}
