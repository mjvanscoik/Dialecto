using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Data
{
    public class Root
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "There are too many characters in this field.")]
        public string RootName { get; set; }
        
    }
}
