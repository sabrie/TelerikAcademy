using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.Repositories;
using Students.Models;
using System.Collections.Generic;
using Telerik.JustMock;
using System.Net;
using System.Linq;

namespace Students.Services.IntegrationTests
{
    [TestClass]
    public class StudentsControllerIntegrationTests
    {
        [TestMethod]
        public void GetAll_WhenOneStudent_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            models.Add(new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Age = 23,
                Grade = 5
            });

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetAll_WhenNoStudents_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            
            var models = new List<Student>();

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostStudent_WhenValid_ShouldReturnStatusCode201()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => mockRepository
                .Add(Arg.Matches<Student>(st => st.FirstName == "Pesho" && st.LastName == "Peshev")))
                .Returns(
                    new Student()
                    {
                        FirstName = "Pesho",
                        LastName = "Peshev"
                    }
                );

            var server =
                new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var response = server.CreatePostRequest("api/students",
                new Student()
                {
                    FirstName = "Pesho",
                    LastName = "Peshev",
                });

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
