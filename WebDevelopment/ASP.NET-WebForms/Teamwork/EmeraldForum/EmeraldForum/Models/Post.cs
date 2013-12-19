using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmeraldForum.Models
{
    public class Post
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }
        
        [MaxLength(100), Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        public virtual ForumUser User { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}