using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksInventory.Models
{
    [Table("Account")]
    public class Account
    {
        //   F i e l d s   &   P r o p e r t i e s

        
        [Key, Required(ErrorMessage = "Must input your SSN.")]
        public string SSN           { get; set; }     // PK not null, nvarchar 15

        [ForeignKey("Unit")]
        public int     UnitId       { get; set; }     // FK, (Unit) not null

        [Required(ErrorMessage = "Must have a name.")]
        public string  Name         { get; set; }     // not null nvarcar 40

        [Required(ErrorMessage = "Must have a phone number.")]
        public string  Phone        { get; set; }     // not null, nvarchar 20

        [Required(ErrorMessage = "Must have an address.")]
        public string  Address      { get; set; }     // not null, nvarchar 100

        //   C o n s t r u c t o r s

        //   M e t h o d s

    }
}
