using System.Linq;

namespace BarracksInventory.Models
{
    internal interface IAccountRepository
    {
        // create

        public Unit AddAccount(Account u);

        // read

        public IQueryable<Account> GetAllAccounts();
        public Unit GetAccountByLast4(string last4);
        public IQueryable<Account> GetAccountByKeyword(string word);


        // update

        public Unit EditAccount(Account u);


        // delete

        public bool DeleteAccount(int id);

    }
}