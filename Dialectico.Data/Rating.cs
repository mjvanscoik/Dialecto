﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Data
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Range(0,10)]
        public int IndividualRating { get; set; }
        
        public string Comment { get; set; }


        [ForeignKey(nameof(Meaning))]
        public int MeaningId { get; set; }
        public virtual Meaning Meaning { get; set; }
    
    }
}
