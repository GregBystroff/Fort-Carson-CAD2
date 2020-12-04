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
        public IActionResult AddAccount(Account a)
        {
            if (ModelState.IsValid)
            {
                    _repository.AddAccount(a);
                    return RedirectToAction("AccountDetail", a.SSN);
                    // return View("AccountDetail", a);
            }
            else
            {
                return View(a);
            }
        }


        // R e a d

        public IActionResult AccountDetail(string SSN)
        {
            Account requestedAccount = _repository.GetAccountBySSN(SSN);
            return View(requestedAccount);
        }

        // GetAccountsByUnit Method

        // GetAll Accounts Method


        // U p d a t e

        [HttpGet]
        public IActionResult EditAccount(string SSN)
        {

            Account a = _repository.GetAccountBySSN(SSN);

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
            return RedirectToAction("AccountDetail", updatedAccount);
        }


        // D e l e t e

        [HttpGet]
        public IActionResult DeleteAccount(string SSN)
        {
            Account account = _repository.GetAccountBySSN(SSN);
            if (account != null)
            {
                return View(account);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAccount(Account account, string SSN)
        {
            _repository.DeleteAccount(SSN);
            return RedirectToAction("Index");
        }

    }
}
