using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksInventory.Models
{
    interface IInspectionRepository
    {
        // create

        public Inspection AddInspection(Inspection i);

        // read

        public IQueryable<Inspection> GetAccountInspections(Account a);
        public Inspection GetInspectionById(int id);

        // update

        // never!

        // delete

        // never!

    }
}
