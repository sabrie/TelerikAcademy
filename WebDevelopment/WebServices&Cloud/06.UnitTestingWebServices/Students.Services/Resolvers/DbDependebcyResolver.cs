using Students.DataLayer;
using Students.Models;
using Students.Repositories;
using Students.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Mvc;


namespace Students.Services.Resolvers
{
    public class DbDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private static DbContext studentsContext = new StudentsContext();

        private static IRepository<Student> repository = new DbStudentRepository(studentsContext);


        //public IDependencyScope BeginScope()
        //{
        //    return this;
        //}

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(repository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}