﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.RelationManyToMany;

namespace Data.Entities.Characterize
{
    [Table("Protections")]
    public class Protection : IModel<Protection>
    {
        /// <summary>
        /// Columns
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Wording { get; set; }
        public string Alias { get; set; }

        public int IdPart { get; set; }
        public int Value { get; set; }

        public virtual Part Part { get; set; }

        public ICollection<CharacterProtection> CharacterProtections { get; set; }
    }

}
