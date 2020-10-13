using Dialectico.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Models
{
    public class WordDetail
    {
        public int WordId { get; set; }

        [DisplayName("Root")]
        public string RootName { get; set; }

        
        public string Notes { get; set; }

        [DisplayName("Word")]
        public string WordName { get; set; }
        public virtual List<MeaningListItem> Meanings {get; set;}
    }
}
