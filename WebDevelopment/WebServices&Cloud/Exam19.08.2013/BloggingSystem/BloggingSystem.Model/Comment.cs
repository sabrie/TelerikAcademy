﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public DateTime PostDate { get; set; }
    }
}
