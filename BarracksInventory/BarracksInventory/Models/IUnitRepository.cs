using System.Linq;

namespace BarracksInventory.Models
{
    public interface IUnitRepository
    {

        // create

        public Unit AddUnit(Unit u);


        // read

        public IQueryable<Unit> GetAllUnits();
        public IQueryable<Unit> GetUnitByKeyword(string word);
        public Unit GetUnitById(int id);


        // update

        public Unit EditUnit(Unit u);


        // delete

        public bool DeleteUnit(int id);

    }
}
