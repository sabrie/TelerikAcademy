﻿using BloggingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.DataLayer
{
    public class BloggingSystemContext : DbContext
    {
        public BloggingSystemContext()
            : base("BloggingSystemDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .Property(usr => usr.SessionKey)
        //        .IsFixedLength()
        //        .HasMaxLength(40);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
