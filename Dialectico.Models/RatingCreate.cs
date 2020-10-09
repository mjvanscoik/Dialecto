using Dialectico.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Models
{
    public class RatingCreate
    {
        public int IndividualRating { get; set; }

        public string Comment { get; set; }

        public virtual Meaning Meaning { get; set; }

        public int MeaningId { get; set; }
    }
}
