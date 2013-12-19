using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmeraldForum.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}