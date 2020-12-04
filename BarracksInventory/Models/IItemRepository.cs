using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksInventory.Models
{
    public interface IItemRepository
    {
        // create

        public Item AddItem(Item i);

        // read

        public IQueryable<Item> GetAccountItems(Account a);
        public Item GetItemById(int id);
        public IQueryable<Item> GetItemByKeyword(string word);

        // update

        public Item EditItem(Item i);

        // delete

        public bool DeleteItem(int id);

    }
}
