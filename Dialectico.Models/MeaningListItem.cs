using Dialectico.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Models
{
    public class MeaningListItem
    {
        public int MeaningId { get; set; }
        public string WordName { get; set; }

        public string Pronunciation { get; set; }

        public string Context { get; set; }
        public string Description { get; set; }

        //[Range(0, 10)]
        public double? CumulativeRating { get; set; }

        public Dialect RegionalDialect { get; set; }

        public List<Dialect> DialectList { get; set; }

        public List<Rating> RatingsList { get; set; }

        public int WordId { get; set; }

        public virtual Word Word { get; set; }
    }
}

