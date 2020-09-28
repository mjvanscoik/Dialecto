using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Models
{
   public class RootCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "A root must consist of at least one letter.")]
        [MaxLength(14, ErrorMessage = "There are too many characters in this field.")]
        public string RootName { get; set; }

        [Required]
        public string NotesOnRoot { get; set; }
    }
}
