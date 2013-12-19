using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmeraldForum.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ForumUser User { get; set; }

        public virtual Post Post { get; set; }
    }
}