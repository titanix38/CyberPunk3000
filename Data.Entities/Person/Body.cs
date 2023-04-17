﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Person
{
    [Table("Bodies")]
    public class Body
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBody { get; set; }
        public string Wording { get; set; }
        public int Penalty { get; set; }
        public int Factor { get; set; }




    }
}