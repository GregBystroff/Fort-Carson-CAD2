﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarracksInventory.Models
{

    [Table("Inspection")]
    public class Inspection
    {
        public int      inspectId   { get; set; }     // PK, not null, Autogenerated
        public int      unitId      { get; set; }     // FK, (Unit) not null
        public int      userId      { get; set; }     // FK, (Account) not null
        public DateTime inspectDate { get; set; }     // not null, date
        public string   address     { get; set; }     // not null
        public string   status      { get; set; }     // restrict status
    }
}