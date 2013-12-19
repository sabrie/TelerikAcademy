using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace EmeraldForum.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ForumUser : User
    {
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string PhotoPath { get; set; }
    }

    public class ForumEmeraldContext : IdentityDbContext<ForumUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public ForumEmeraldContext()
            : base("ForumEmereald")
        {
        }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}