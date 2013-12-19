using Students.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.DataLayer
{
    public class StudentsContext : DbContext
    {
        public StudentsContext()
            : base("StudentsEntities")
        {            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<School> Schools { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>()
        //                .Property(s => s.FirstName)
        //                .IsRequired();
        //    modelBuilder.Entity<Student>()
        //                .Property(s => s.LastName)
        //                .IsRequired();

        //    modelBuilder.Entity<School>()
        //                .Property(s => s.Name)
        //                .IsRequired().HasMaxLength(55);

        //    modelBuilder.Entity<Mark>()
        //                .Property(m => m.Subject)
        //                .IsRequired()
        //                .HasMaxLength(100);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
