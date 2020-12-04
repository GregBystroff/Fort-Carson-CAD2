using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksInventory.Models
{
    public interface IInspectionRepository
    {
        // create

        public Inspection AddInspection(Inspection i);

        // read

        public IQueryable<Inspection> GetAccountInspections(Unit u);

        public Inspection GetInspectionById(int id);

        // update

        // never!

        // delete

        // never!

    }
}
