using Dialectico.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Models
{
    public class RootListItem
    {
        public int Id { get; set; }

        public string RootName { get; set; }

        public string NotesOnRoot { get; set; }

        public virtual List<WordListItem> WordsList { get; set; }
    }
}
