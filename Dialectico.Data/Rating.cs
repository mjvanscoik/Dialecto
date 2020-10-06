using System;
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

        public int UserRating { get; set; }
        
        public string Comment { get; set; }


        [ForeignKey(nameof(Meaning))]
        public int MeaningId { get; set; }
        public Meaning Meaning { get; set; }
    
    }
}
