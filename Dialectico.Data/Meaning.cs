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
        [Key]
        public int MeaningId { get; set; }

        [ForeignKey(nameof(Word))]
        public int WordId { get; set; }
        public string WordName { get; set; }// meaning service

        public virtual Word Word { get; set; }
        public string Pronunciation { get; set; }

        public string Context { get; set; }
        public string Description { get; set; }

        [Range(0, 10)]
        public double UserRating { get; set; }

        public virtual List<Rating> Ratings { get; set; }

        public Dialect RegionalDialect { get; set; }

        public List<Dialect> DialectList { get; set; }
    }
    public enum Dialect
    {
        [Display(Name = "Misc.")]
        Misc,
        [Display(Name = "Algerian")]
        Algerian,
        [Display(Name = "Bahraini")]
        Bahraini,
        [Display(Name = "Comoros Islands")]
        ComorosIslands,
        [Display(Name = "Djibouti")]
        Djibouti,
        [Display(Name = "Egyptian")]
        Egyptian,
        [Display(Name = "Iraqi")]
        Iraqi,
        [Display(Name = "Jordanian")]
        Jordanian,
        [Display(Name = "Kuwaiti")]
        Kuwaiti,
        [Display(Name = "Lebanese")]
        Lebanese,
        [Display(Name = "Lybian")]
        Lybian,
        [Display(Name = "Morrocan")]
        Morrocan,
        [Display(Name = "Mauritanian")]
        Mauritanian,
        [Display(Name = "Omani")]
        Omani,
        [Display(Name = "Palestinian")]
        Palestinian,
        [Display(Name = "Qatari")]
        Qatari,
        [Display(Name = "Saudi")]
        Saudi,
        [Display(Name = "Somali")]
        Somali,
        [Display(Name = "Sudanese")]
        Sudanese,
        [Display(Name = "Syrian")]
        Syrian,
        [Display(Name = "Tunisian")]
        Tunisian,
        [Display(Name = "Emarati")]
        Emarati,
        [Display(Name = "Yemeni")]
        Yemeni,
        [Display(Name = "Modern Standard")]
        ModernStandard,
        [Display(Name = "Classical Arabic")]
        ClassicalArabic,
        [Display(Name = "Quaranic Arabic")]
        Quranic
    }
}


