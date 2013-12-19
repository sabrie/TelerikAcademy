using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Students.Models;
using Students.DataLayer;
using Students.Repositories;
using Students.Services.Models;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentsContext db = new StudentsContext();

        private IRepository<Student> studentsRepository;

        public StudentsController(IRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        // GET api/Students
        public IEnumerable<StudentModel> GetAll()
        {
            var studentEntities = this.studentsRepository.All();
            var studentModels =
                from studEntity in studentEntities
                select new StudentModel()
                {
                    StudentId = studEntity.StudentId,
                    FirstName = studEntity.FirstName,
                    LastName = studEntity.LastName,
                    Age = studEntity.Age
                };
            return studentModels.ToList();
        }

        // GET api/Students/5
        public Student GetSingle(int id)
        {
            var entity = this.studentsRepository.Get(id);
            Student student = new Student()
            {
                StudentId = entity.StudentId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Marks = (from mark in entity.Marks
                          select new Mark()
                          {
                              MarkId = mark.MarkId,
                              Subject = mark.Subject,
                              Value = mark.Value,
                          }).ToList()
            };

            return student;
        }

        // POST api/Students
        public HttpResponseMessage PostStudent(StudentModel student)
        {
            if (student != null)
            {
                var entityToAdd = new Student()
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Grade = student.Grade
                };

                var createdEntity = this.studentsRepository.Add(entityToAdd);

                var createdModel = new StudentModel()
                {
                    StudentId = createdEntity.StudentId,
                    FirstName = createdEntity.FirstName,
                    Age = createdEntity.Age
                };

                var response = Request.CreateResponse<StudentModel>(HttpStatusCode.Created, createdModel);
                var resourceLink = Url.Link("DefaultApi", new { id = createdModel.StudentId });

                response.Headers.Location = new Uri(resourceLink);

                return response;
            }

            return Request.CreateResponse<StudentModel>(HttpStatusCode.BadRequest, student);
        }        

        // TODO
        public IEnumerable<Student> GetStudents(string subject, decimal value)
        {
            IEnumerable<Student> studentEntities = this.db.Students.Where(s => s.Marks.Any(m => (m.Subject == subject && m.Value > value)));

            return studentEntities;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}