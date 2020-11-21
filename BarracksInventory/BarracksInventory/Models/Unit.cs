using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksInventory.Models
{
    [Table("Unit")]
    public class Unit
    {
        public int      UnitId      { get; set; }     // PK, (EfUnitRepository), not null AutoGen
        public string   UnitName    { get; set; }     // not null nvarcar 40
        public string   UnitRep     { get; set; }     // null, nvarchar 40
        public string   RepPhone    { get; set; }     // not null, nvarchar 15
        public string   UnitAddress { get; set; }     // not null, nvarchar 40
    }
}
