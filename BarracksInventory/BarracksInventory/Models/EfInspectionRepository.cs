using System.Linq;

namespace BarracksInventory.Models
{
    public class EfInspectionRepository : IInspectionRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext _context;

        //   C o n s t u c t o r s

        public EfInspectionRepository(AppDbContext context)
        {
            _context = context;
        }

        //   M e t h o d s

        // create

        public Inspection AddInspection(Inspection i)
        {
            _context.Inspections.Add(i);
            _context.SaveChanges();
            return i;

        }

        // read

        public IQueryable<Inspection> GetAccountInspections(Unit u)
        {
            return _context.Inspections.Where(insp => insp.UnitId.Equals(u.UnitId));
        }

        public Inspection GetInspectionById(int id)
        {
            return _context.Inspections.Find(id);
        }

        // update

        // never!

        // delete

        // never!


    }
}
