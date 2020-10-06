using Dialectico.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Models
{
    public class WordDetail
    {
        public int WordId { get; set; }
        public string RootName { get; set; }
        public string Notes { get; set; }
        public string WordName { get; set; }
        public virtual List<MeaningListItem> Meanings {get; set;}
    }
}
