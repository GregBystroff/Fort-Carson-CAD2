using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksInventory.Models
{
    public class EfUnitRepository
        : IUnitRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext _context;
        //   C o n s t r u c t o r s

        public EfUnitRepository(AppDbContext context)
        {
            _context = context;
        }

        //   M e t h o d s
        
        // create
        public Unit AddUnit(Unit u)
        {
            _context.Units.Add(u);
            _context.SaveChanges();
            return u;
        }

        // read

        public IQueryable<Unit> GetAllUnits()
        {
            return _context.Units;
        }

        public IQueryable<Unit> GetUnitByKeyword(string word)
        {
            return _context.Units.Where(unit => unit.Name.Contains(word));
        }

        public Unit GetUnitById(int id)
        {
            return _context.Units.Find(id);
        }

        // update

        public Unit EditUnit(Unit u)
        {
            Unit unitToEdit = _context.Units.Find(u.UnitId);
            if (unitToEdit != null)
            {
                unitToEdit.Name = u.Name;
                unitToEdit.Address = u.Address;
                unitToEdit.Rep = u.Rep;
                unitToEdit.Phone = u.Phone;
                _context.SaveChanges();
            }
            return unitToEdit;
        }

        // delete

        public bool DeleteUnit(int id)
        {
            Unit unitToDelete = _context.Units.Find(id);
            if(unitToDelete != null)
            {
                _context.Units.Remove(unitToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
            
        }

    }
}
