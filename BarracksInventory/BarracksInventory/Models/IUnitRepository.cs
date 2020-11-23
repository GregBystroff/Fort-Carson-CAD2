using System.Linq;

namespace BarracksInventory.Models
{
    interface IUnitRepository
    {
        //   F i e l d s   and   P r o p e r t i e s
        IQueryable<Unit> Units { get; }

        // Constructors (not in an interface)
        // Methods

        public IQueryable<Unit> GetAllUnits();
    }
}
