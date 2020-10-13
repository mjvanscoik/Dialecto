using Dialectico.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Models
{
    public class RootListItem
    {
        public int Id { get; set; }

        [DisplayName("Root")]
        public string RootName { get; set; }

        [DisplayName("Notes")]
        public string NotesOnRoot { get; set; }

        public virtual List<WordListItem> WordsList { get; set; }
    }
}
