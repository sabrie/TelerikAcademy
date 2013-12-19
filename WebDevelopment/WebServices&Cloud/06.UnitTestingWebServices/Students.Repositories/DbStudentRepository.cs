using Students.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repositories
{
    interface IStudentRepository : IRepository<Student>
    {
    }

    public class DbStudentRepository : IStudentRepository
    {
        private DbContext dbContext;
        private DbSet<Student> entitySet;

        public DbStudentRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Student>();
        }

        public Student Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Student> All()
        {
            return this.entitySet;
        }

        public Student Add(Student entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public IQueryable<Student> Find(Expression<Func<Student, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}
