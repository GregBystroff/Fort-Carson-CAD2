using System.Linq;

namespace BarracksInventory.Models
{
    public interface IAccountRepository
    {
        // create

        public Account AddAccount(Account a);


        // read

        public IQueryable<Account> GetAllAccounts();

        public Account GetAccountBySSN(string SSN);

        public IQueryable<Account> GetAccountByKeyword(string word);


        // update

        public Account EditAccount(Account a);


        // delete

        public bool DeleteAccount(string ssn);

    }
}