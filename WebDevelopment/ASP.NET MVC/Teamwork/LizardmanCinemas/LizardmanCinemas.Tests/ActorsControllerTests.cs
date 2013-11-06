using LizardmanCinemas.Controllers;
using LizardmanCinemas.Data;
using LizardmanCinemas.Models;
using LizardmanCinemas.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LizardmanCinemas.Tests
{
    [TestClass]
    public class ActorsControllerTests
    {
        [TestMethod]
        public void IndexShouldReturnAllActors()
        {
            var list = new List<Actor>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Actor()
            {
                Id = i,
                FirstName = "Pesho",
                LastName = "Peshev"
            });
            }
            var movieRepoMock = new Mock<IRepository<Actor>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uowMock = new Mock<IUowData>();
            uowMock.Setup(x => x.Actors).Returns(movieRepoMock.Object);

            var controller = new ActorsController(uowMock.Object);

            var viewresult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var models = viewresult.Model as IEnumerable<ActorsShortViewModel>;
            Assert.IsNotNull(models, "The model is Null");
            Assert.AreEqual(list.Count, models.Count());
        }

        [TestMethod]
        public void IndexShouldReturnActorShortViewModels()
        {
            var list = new List<Actor>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Actor()
                {
                    Id = i,
                    FirstName = "Pesho",
                    LastName = "Peshev"
                });
            }
            var movieRepoMock = new Mock<IRepository<Actor>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uowMock = new Mock<IUowData>();
            uowMock.Setup(x => x.Actors).Returns(movieRepoMock.Object);

            var controller = new ActorsController(uowMock.Object);

            var viewresult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var models = viewresult.Model as IEnumerable<ActorsShortViewModel>;
            Assert.IsNotNull(models, "The model is Null");
            Assert.IsInstanceOfType(models.First(), typeof(ActorsShortViewModel));

        }

        [TestMethod]
        public void DetailsViewShouldReturnOneActor()
        {
            var list = new List<Actor>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Actor()
                {
                    Id = i,
                    FirstName = "Pesho",
                    LastName = "Peshev"
                });
            }

            var movieRepoMock = new Mock<IRepository<Actor>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uowMock = new Mock<IUowData>();
            uowMock.Setup(x => x.Actors).Returns(movieRepoMock.Object);

            var controller = new ActorsController(uowMock.Object);

            var viewresult = controller.DetailsView(1) as PartialViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var model = viewresult.Model as ActorDetails;
            Assert.IsNotNull(model, "The model is Null");
        }

        [TestMethod]
        public void DetailsViewShouldReturnCorrectActor()
        {
            var list = new List<Actor>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Actor()
                {
                    Id = i,
                    FirstName = "Pesho",
                    LastName = "Peshev"
                });
            }

            var expected = new ActorDetails()
            {
                 FullName = "Pesho Peshev"
            };

            var movieRepoMock = new Mock<IRepository<Actor>>();
            movieRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uowMock = new Mock<IUowData>();
            uowMock.Setup(x => x.Actors).Returns(movieRepoMock.Object);

            var controller = new ActorsController(uowMock.Object);

            var viewresult = controller.DetailsView(1) as PartialViewResult;
            Assert.IsNotNull(viewresult, "ViewResult is Null");
            var resModel = viewresult.Model;
            var model = viewresult.Model as ActorDetails;
            Assert.IsNotNull(model, "The model is Null");
            Assert.AreEqual(expected.FullName, model.FullName);
        }
    }
}
