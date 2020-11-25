using System.Linq;

namespace BarracksInventory.Models
{
    public class EfItemRepository
        : IItemRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext _context;

        //   C o n s t r u c t o r s

        public EfItemRepository(AppDbContext context)
        {
            _context = context;
        }

        //   M e t h o d s

        // create
        public Item AddItem(Item i)
        {
            _context.Items.Add(i);
            _context.SaveChanges();
            return i;
        }

        // read

        public IQueryable<Item> GetAccountItems(Account a)
        {
            return _context.Items.Where(item => item.SSN.Equals(a.SSN));
        }

        public IQueryable<Item> GetItemByKeyword(string word)
        {
            return _context.Items.Where(item => item.Name.Contains(word));
        }

        public Item GetItemById(int id)
        {
            return _context.Items.Find(id);
        }

        // update

        public Item EditItem(Item i)
        {
            Item itemToEdit = _context.Items.Find(i.ItemId);
            if (itemToEdit != null)
            {
                itemToEdit.Name = i.Name;
                itemToEdit.Qty = i.Qty;
                itemToEdit.Price = i.Price;
                _context.SaveChanges();
            }
            return itemToEdit;
        }

        // delete

        public bool DeleteItem(int id)
        {
            Item itemToDelete = _context.Items.Find(id);
            if (itemToDelete != null)
            {
                _context.Items.Remove(itemToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
