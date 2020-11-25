using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksInventory.Models
{
    [Table("Account")]
    public class Account
    {
        //   F i e l d s   &   P r o p e r t i e s

        public string SSN           { get; set; }     // PK not null, nvarchar 15
        [ForeignKey("Unit")]
        public int     UnitId       { get; set; }     // FK, (Unit) not null
        public string  Name         { get; set; }     // not null nvarcar 40
        public string  Phone        { get; set; }     // not null, nvarchar 20
        public string  Address      { get; set; }     // not null, nvarchar 100

        //   C o n s t r u c t o r s

        //   M e t h o d s

    }
}
