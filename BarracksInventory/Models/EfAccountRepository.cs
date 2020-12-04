using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksInventory.Models
{
    public class EfAccountRepository : IAccountRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext _context;

        //   C o n s t u c t o r s

        public EfAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        //   M e t h o d s

        // create
        public Account AddAccount(Account a)
        {
            _context.Accounts.Add(a);
            _context.SaveChanges();
            return a;
        }

        // read

        public IQueryable<Account> GetAllAccounts()
        {
            return _context.Accounts;
        }

        public IQueryable<Account> GetAccountByKeyword(string word)
        {
            return _context.Accounts.Where(account => account.Name.Contains(word));
        }

        public Account GetAccountBySSN(string SSN)
        {
            return _context.Accounts.Where(a => SSN == a.SSN)
                    .FirstOrDefault();
                    
        }

        // update

        public Account EditAccount(Account a)
        {
            Account accountToEdit = _context.Accounts.Find(a.UnitId);
            if (accountToEdit != null)
            {
                accountToEdit.Name = a.Name;
                accountToEdit.Address = a.Address;
                accountToEdit.Phone = a.Phone;
                _context.SaveChanges();
            }
            return accountToEdit;
        }

        // delete

        public bool DeleteAccount(string ssn)
        {
            Account accountToDelete = _context.Accounts.Where(acct => acct.SSN.Contains(ssn)).FirstOrDefault();
            if (accountToDelete != null)
            {
                _context.Accounts.Remove(accountToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
