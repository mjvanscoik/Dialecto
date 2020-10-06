﻿using Dialectico.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Models
{

    public class MeaningCreate
    {
        public string WordName { get; set; }
        public string Pronunciation { get; set; }
        public string Context { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Dialect RegionalDialect { get; set; }

    }
}
