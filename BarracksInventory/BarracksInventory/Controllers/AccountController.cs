using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BarracksInventory.Models;

namespace BarracksInventory.Controllers
{
    public class AccountController : Controller
    {
        // F i e l d s   &    P r o p e r t i e s


        private IAccountRepository _repository;


        // C o n t r o l l e r s 

        public AccountController(IAccountRepository accountRepository)
        {
            _repository = accountRepository;
        }


        // M e t h o d s

        // C r e a t e

        [HttpGet]
        public IActionResult AddAccount()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult AddAccount(Account a)
        {
            if (ModelState.IsValid)
            {
                if (a.Password == a.ConfirmPassword)
                {
                    _repository.AddAccount(a);
                    RedirectToAction("AccountDetail", a.AccountId);
                    return View("UserHome", a);
                }
                else
                {
                    return View(a);
                }
            }
            else
            {
                return View(a);
            }
        }


        // R e a d

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        // U p d a t e

        [HttpGet]
        public IActionResult EditAccount(int acctId)
        {

            Account a = _repository.GetAccountById(acctId);

            if(a != null)
            {
                return View(a);

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditAccount(Account a)
        {
            Account updatedAccount = _repository.EditAccount(a);
            if (updatedAccount == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(new { acctId = a.AccountId });
        }


        // D e l e t e

        [HttpGet]
        public IActionResult DeleteAccount(int id)
        {
            Account account = _repository.GetAccountById(id);
            if (account != null)
            {
                return View(account);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAccount(Account account, int id)
        {
            _repository.DeleteAccount(id);
            return RedirectToAction("Index");
        }

    }
}
