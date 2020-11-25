using System.Linq;

namespace BarracksInventory.Models
{
    interface IUnitRepository
    {

        // create

        public Unit AddUnit(Unit u);

        // read

        public IQueryable<Unit> GetAllUnits();
        public Unit GetUnitById(int id);
        public IQueryable<Unit> GetUnitByKeyword(string word);


        // update

        public Unit EditUnit(Unit u);


        // delete

        public bool DeleteUnit(int id);

    }
}
