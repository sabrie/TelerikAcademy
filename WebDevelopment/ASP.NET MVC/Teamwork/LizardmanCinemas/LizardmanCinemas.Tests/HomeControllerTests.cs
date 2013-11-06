using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LizardmanCinemas.Controllers;
using LizardmanCinemas.Data;
using LizardmanCinemas.Models;
using LizardmanCinemas.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LizardmanCinemas.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexShouldReturnThreeMoviesWhenMore()
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "pesho"
            };

            var list = new List<Movie>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Movie()
                {
                    Id = i,
                    Title = "pesho",
                    Poster = "c.jpg",
                    Year = 2000,
                    Trailer = "pesho.com",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                         CommentText="asssaaa",
                          CreatedOn = DateTime.Now,
                           Id = 1,
                            User = user
                        }
                    }
                });
            }
            
            var movieRepoMock = new Mock<IRepository<Movie>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());
            //movieRepoMock.Setup(x=>x.All().Take(3).Select(MovieHomeVM.FromMovie).ToList()).Returns(list);

            var uowMock = new Mock<IUowData>();
            //uowMock.Setup(x=>x.SaveChanges()).Returns(()=>{return 3});
            uowMock.Setup(x => x.Movies).Returns(movieRepoMock.Object);

            var controller = new HomeController(uowMock.Object);

            var viewresult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var model = viewresult.Model as IEnumerable<MovieHomeVM>;
            Assert.IsNotNull(model, "The model is Null");
            Assert.AreEqual(3, model.Count());
        }

        [TestMethod]
        public void IndexShouldReturnOneMovieWhenOne()
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "pesho"
            };

            var list = new List<Movie>();

                list.Add(new Movie()
                {
                    Id = 1,
                    Title = "pesho",
                    Poster = "c.jpg",
                    Year = 2000,
                    Trailer = "pesho.com",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                         CommentText="asssaaa",
                          CreatedOn = DateTime.Now,
                           Id = 1,
                            User = user
                        }
                    }
                });

            var movieRepoMock = new Mock<IRepository<Movie>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uowMock = new Mock<IUowData>();
            uowMock.Setup(x => x.Movies).Returns(movieRepoMock.Object);

            var controller = new HomeController(uowMock.Object);

            var viewresult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var model = viewresult.Model as IEnumerable<MovieHomeVM>;
            Assert.IsNotNull(model, "The model is Null");
            Assert.AreEqual(1, model.Count());
        }

        [TestMethod]
        public void IndexShouldReturnThreeMoviesWhenThreeAvailable()
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "pesho"
            };

            var list = new List<Movie>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new Movie()
                {
                    Id = i,
                    Title = "pesho",
                    Poster = "c.jpg",
                    Year = 2000,
                    Trailer = "pesho.com",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                         CommentText="asssaaa",
                          CreatedOn = DateTime.Now,
                           Id = 1,
                            User = user
                        }
                    }
                });
            }

            var movieRepoMock = new Mock<IRepository<Movie>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());
            //movieRepoMock.Setup(x=>x.All().Take(3).Select(MovieHomeVM.FromMovie).ToList()).Returns(list);

            var uowMock = new Mock<IUowData>();
            //uowMock.Setup(x=>x.SaveChanges()).Returns(()=>{return 3});
            uowMock.Setup(x => x.Movies).Returns(movieRepoMock.Object);

            var controller = new HomeController(uowMock.Object);

            var viewresult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var model = viewresult.Model as IEnumerable<MovieHomeVM>;
            Assert.IsNotNull(model, "The model is Null");
            Assert.AreEqual(3, model.Count());
        }

        [TestMethod]
        public void IndexSahouldReturnZero()
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "pesho"
            };

            var list = new List<Movie>();         

            var movieRepoMock = new Mock<IRepository<Movie>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uowMock = new Mock<IUowData>();
            uowMock.Setup(x => x.Movies).Returns(movieRepoMock.Object);

            var controller = new HomeController(uowMock.Object);

            var viewresult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var model = viewresult.Model as IEnumerable<MovieHomeVM>;
            Assert.IsNotNull(model, "The model is Null");
            Assert.AreEqual(0, model.Count());
        }

        [TestMethod]
        public void IndexShouldReturnCorrectViewModel()
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "pesho"
            };

            DateTime date = new DateTime(2000, 10, 22);

            var list = new List<Movie>();

            list.Add(new Movie()
            {
                Id = 1,
                Title = "pesho",
                Poster = "c.jpg",
                Year = 2000,
                Trailer = "pesho.com",
                Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                         CommentText="asssaaa",
                          CreatedOn = date,
                           Id = 1,
                            User = user
                        }
                    }
            });

            var expected = new MovieHomeVM()
            {
                Id = 1,
                Title = "pesho",
                Poster = "c.jpg",
                Year = 2000,
                Trailer = "pesho.com",
                Comments = new List<CommentVM>()
                    {
                        new CommentVM()
                        {
                         CommentText="asssaaa",
                          CreatedOn = date,
                           Username = user.UserName,
                           DisplayDate = date.ToString("dd/MM/yy hh:mm"),
                           MovieName = null
                        }
                    }
            };

            var movieRepoMock = new Mock<IRepository<Movie>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uowMock = new Mock<IUowData>();
            uowMock.Setup(x => x.Movies).Returns(movieRepoMock.Object);

            var controller = new HomeController(uowMock.Object);

            var viewresult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var model = viewresult.Model as IEnumerable<MovieHomeVM>;
            Assert.IsNotNull(model, "The model is Null");
            var actual = model.First();
            Assert.AreEqual(expected.Title, actual.Title);
            Assert.AreEqual(expected.Year, actual.Year);
            Assert.AreEqual(expected.Poster, actual.Poster);
        }

        [TestMethod]
        public void IndexShouldReturnCorrectViewModelDisplayDate()
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "pesho"
            };

            DateTime date = new DateTime(2000, 10, 22);

            var list = new List<Movie>();

            list.Add(new Movie()
            {
                Id = 1,
                Title = "pesho",
                Poster = "c.jpg",
                Year = 2000,
                Trailer = "pesho.com",
                Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                         CommentText="asssaaa",
                          CreatedOn = date,
                           Id = 1,
                            User = user
                        }
                    }
            });

            var expected = new MovieHomeVM()
            {
                Id = 1,
                Title = "pesho",
                Poster = "c.jpg",
                Year = 2000,
                Trailer = "pesho.com",
                Comments = new List<CommentVM>()
                    {
                        new CommentVM()
                        {
                         CommentText="asssaaa",
                          CreatedOn = date,
                           Username = user.UserName,
                           DisplayDate = date.ToString("dd/MM/yy hh:mm"),
                           MovieName = null
                        }
                    }
            };

            var movieRepoMock = new Mock<IRepository<Movie>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uowMock = new Mock<IUowData>();
            uowMock.Setup(x => x.Movies).Returns(movieRepoMock.Object);

            var controller = new HomeController(uowMock.Object);

            var viewresult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var model = viewresult.Model as IEnumerable<MovieHomeVM>;
            Assert.IsNotNull(model, "The model is Null");
            var actual = model.First();
            Assert.AreEqual(expected.Comments.First().DisplayDate, actual.Comments.First().DisplayDate);
        }
    }
}
