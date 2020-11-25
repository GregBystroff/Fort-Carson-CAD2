using System.ComponentModel.DataAnnotations.Schema;

namespace BarracksInventory.Models
{
    [Table("Unit")]
    public class Unit
    {
        public int      UnitId      { get; set; }     // PK, (Unit), not null AutoGen
        public string   Name        { get; set; }     // not null nvarcar 40
        public string   Rep         { get; set; }     // null, nvarchar 40
        public string   Phone       { get; set; }     // not null, nvarchar 15
        public string   Address     { get; set; }     // not null, nvarchar 40
    }
}
