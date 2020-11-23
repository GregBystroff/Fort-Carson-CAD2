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

        private BarracksInventoryDbContext context;
        //   C o n s t r u c t o r s

        public EfUnitRepository(BarracksInventoryDbContext ctex)
        {
            context = ctex;
        }

        //   M e t h o d s
        public IQueryable<Unit> Units => throw new NotImplementedException();

        public IQueryable<Unit> GetAllUnits()
        {
            throw new NotImplementedException();
        }
    }
}
