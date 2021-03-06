﻿namespace Exam.Data
{
    using Exam.Models;
    using System;
    using System.Collections.Generic;

    public class UowData : IUowData
    {
        private readonly ApplicationDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UowData()
            : this(new ApplicationDbContext())
        {
        }

        public UowData(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Ticket> Tickets
        {
            get { return this.GetRepository<Ticket>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }


        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
