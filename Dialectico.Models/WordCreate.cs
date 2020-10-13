using Dialectico.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Models
{
    public class WordCreate
    {
       
        public int WordId { get; set;}

        [Required]
        [DisplayName("Word")]
        public string WordName { get; set; }

        [Required]
        [DisplayName("Root")]
        public string RootName { get; set; }

        public int RootId { get; set; }

        public string Notes { get; set; }

        
    }
}
