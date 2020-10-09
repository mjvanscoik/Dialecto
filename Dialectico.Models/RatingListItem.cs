using Dialectico.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Models
{
    public class RatingListItem
    {
        public int RatingId { get; set; }
        public int IndividualRating { get; set; }

        public string Comment { get; set; }

        public int MeaningId { get; set; }
        public virtual Meaning Meaning { get; set; }
    }
}
