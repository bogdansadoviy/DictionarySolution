using Dictionary.Controllers;
using Dictionary.Data;
using Dictionary.Entities;
using Dictionary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionatyProjectTests.Controllers
{
    public class Tests
    {
        private readonly Guid _userId = DataProvider.CurrentUserId();

        [Test]
        public void Given_UserContainsSelectedWords_When_GetIndexPage_Then_ValidWordCountReturned()
        {
            var homeController = InitControllerWithDbData(DataProvider.Words(), DataProvider.UserWordMappings());
            var result = homeController.Index(false, false);
            var model = ((ViewResult)result).Model as IndexHomeModel;

            Assert.AreEqual(2, model.UserWords.Count);
            Assert.AreEqual(2, model.WordsToLearn.Count);
        }

        [Test]
        public void Given_UserContainsSelectedWords_When_GetIndexPaguntReturned()
        {
            var words = new List<Word>()
            {
                new Word()
                {
                    Id = 1
                },
                 new Word()
                {
                    Id = 2
                },
                  new Word()
                {
                    Id = 3
                },
                  new Word()
                {
                    Id = 4
                },
                  new Word()
                {
                    Id = 5
                },

            };
            var userWordMapping = new List<UserWordMapping>()
            {
                new UserWordMapping()
                {
                    WordId = 1,
                    UserId = _userId
                },
                new UserWordMapping()
                {
                    WordId = 2,
                    UserId = _userId
                },
                new UserWordMapping()
                {
                    WordId = 3,
                    UserId = _userId
                },
                new UserWordMapping()
                {
                    WordId = 4,
                    UserId = _userId
                }
            };
            var homeController = InitControllerWithDbData(words, userWordMapping);
            var result = homeController.Index(false, false);
            var model = ((ViewResult)result).Model as IndexHomeModel;

            Assert.IsTrue(model.IsTestAvaible);
        }

        [Test]
        public void Given_UserContainsSelectedWords_When_GetIndexPtReturned()
        {
            var words = new List<Word>()
            {
                new Word()
                {
                    Id = 1
                },
                 new Word()
                {
                    Id = 2
                },
                  new Word()
                {
                    Id = 3
                }
            };
            var userWordMapping = new List<UserWordMapping>()
            {
                new UserWordMapping()
                {
                    WordId = 1,
                    UserId = _userId
                }
            };
            var homeController = InitControllerWithDbData(words, userWordMapping);
            var result = homeController.Index(false, false);
            var model = ((ViewResult)result).Model as IndexHomeModel;

            Assert.IsFalse(model.IsTestAvaible);
        }

        private HomeController InitControllerWithDbData(List<Word> words, List<UserWordMapping> userWordMappings)
        {
            var wordsAsQueryable = words.AsQueryable();
            var applicationDbContextMock = new Mock<ApplicationDbContext>();
            var wordDbSetMock = new Mock<DbSet<Word>>();
            wordDbSetMock.As<IQueryable<Word>>().Setup(m => m.GetEnumerator()).Returns(wordsAsQueryable.GetEnumerator());
            wordDbSetMock.As<IQueryable<Word>>().Setup(m => m.Provider).Returns(wordsAsQueryable.Provider);
            wordDbSetMock.As<IQueryable<Word>>().Setup(m => m.Expression).Returns(wordsAsQueryable.Expression);
            wordDbSetMock.As<IQueryable<Word>>().Setup(m => m.ElementType).Returns(wordsAsQueryable.ElementType);

            var userWordMappingsQueryable = userWordMappings.AsQueryable();
            var userWordMappingDbSetMock = new Mock<DbSet<UserWordMapping>>();
            userWordMappingDbSetMock.As<IQueryable<UserWordMapping>>().Setup(m => m.GetEnumerator()).Returns(userWordMappingsQueryable.GetEnumerator());
            userWordMappingDbSetMock.As<IQueryable<UserWordMapping>>().Setup(m => m.Provider).Returns(userWordMappingsQueryable.Provider);
            userWordMappingDbSetMock.As<IQueryable<UserWordMapping>>().Setup(m => m.Expression).Returns(userWordMappingsQueryable.Expression);
            userWordMappingDbSetMock.As<IQueryable<UserWordMapping>>().Setup(m => m.ElementType).Returns(userWordMappingsQueryable.ElementType);

            applicationDbContextMock.Setup(_ => _.Words)
                .Returns(wordDbSetMock.Object);
            applicationDbContextMock.Setup(_ => _.UserWordMappings)
                .Returns(userWordMappingDbSetMock.Object);

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(m => m.User).Returns(DataProvider.UserClaims());

            return new HomeController(applicationDbContextMock.Object)
            {
                ControllerContext = new ControllerContext(new ActionContext(httpContext.Object, new RouteData(), new ControllerActionDescriptor()))
            };
        }
    }
}