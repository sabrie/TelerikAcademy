using System;
using Exam.Models;

namespace Exam.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }
        
        IRepository<Ticket> Tickets { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Category> Categories { get; }

        int SaveChanges();
    }
}
