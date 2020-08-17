using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestCreatorWebApp.Db;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Services;
using Xunit;
using AutoMapper;
using TestCreatorWebApp.Controllers;
using TestCreatorWebApp.Dtos;
using UnitTests.Helpers;

namespace UnitTests.Services
{
    public class QuestionServiceTests
    {
        private readonly QuestionService _questionService;

        public QuestionServiceTests()
        {
            var options = new DbContextOptionsBuilder<TestCreatorContext>()
                .UseInMemoryDatabase(databaseName: "testCreatorTest" + DateTime.Now.ToFileTimeUtc())
                .Options;

            var context = new TestCreatorContext(options);

            _questionService = new QuestionService(context, AutoMapperHelper.Mapper);
        }

        [Fact]
        public void Add_AddQuestionToDbAndCheckIfAdded_ReturnsAddedShop()
        {
            // Arrange
            var questionDto = new QuestionDto()
            {
                Quiz = new QuizDto(),
                Text = "test text",
                Notes = "test notes",
                Type = 1,
                Flags = 1,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };

            // Act
            var result = _questionService.Add(questionDto);

            // Assert
            var questionFromDb = _questionService.GetAllQuestions();
            Assert.NotNull(questionFromDb);
            Assert.Equal(questionFromDb.First(), result);
            Assert.Single(questionFromDb);
        }
    }
}
