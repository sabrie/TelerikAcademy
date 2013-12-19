using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Exam.Models;

namespace Exam.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Ticket> Tickets { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Category> Categories { get; set; }

        //public System.Data.Entity.DbSet<Exam.Models.CommentViewModel> CommentViewModel { get; set; }
    }
}
