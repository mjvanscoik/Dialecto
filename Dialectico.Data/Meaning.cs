using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Data
{
   public class Meaning
    {
        public int MeaningId { get; set; }

        [ForeignKey(nameof(Word))]
        public int WordId { get; set; }
        public virtual Word Word { get; set; }

        public string Context { get; set; }
        public string Description { get; set; }

        [Range(0, 10)]       
        public double UserRating { get; set; }

        [ForeignKey(nameof(Rating))]
        public int RatingId { get; set; }
        public virtual Rating Rating { get; set; }

        public List<Dialect> DialectList { get; set; }
        public enum Dialect { Algerian, Bahrani, ComorosIslands, Djibouti, Egyptian, Iraqi, Jordanian, Kuwaiti, Lebanese, Lybian, Morrocan, Mauritanian, Omani, Palistinian, Qatari, Saudi, Somali, Sudanese, Syrian, Tunisian, Emarati, Yemeni, ModernStandard, ClassicalArabic, Quranic }
    }
    
}
