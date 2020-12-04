using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarracksInventory.Models
{
    [Table("Unit")]
    public class Unit
    {
        public int      UnitId      { get; set; }     // PK, (Unit), not null AutoGen

        [Required(ErrorMessage = "Must have a unit name.")]
        public string   Name        { get; set; }     // not null nvarcar 40

        [Required(ErrorMessage = "Must have a unit representative name.")]
        public string   Rep         { get; set; }     // null, nvarchar 40

        [Required(ErrorMessage = "Must have a unit representative phone number.")]
        public string   Phone       { get; set; }     // not null, nvarchar 15

        [Required(ErrorMessage = "Must have a unit address.")]
        public string   Address     { get; set; }     // not null, nvarchar 40
    }
}
