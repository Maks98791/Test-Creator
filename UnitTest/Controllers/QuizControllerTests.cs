using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestCreatorWebApp.Controllers;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Services;
using Xunit;

namespace UnitTests.Controllers
{
    public class QuizControllerTests
    {
        [Fact]
        public void Latest_ReturnsQuizzesListWithSizeOf10_WhenNoPassedParameterInQuery()
        {
            // Arrange
            var quizzesList = new List<Quiz>();
            for (var i = 0; i < 10; i++)
            {
                quizzesList.Add(new Quiz());
            }
            var mockService = new Mock<IQuizService>();
            mockService.Setup(service => service.GetLatest(10))
                .Returns(quizzesList);
            var controller = new QuizController(mockService.Object);

            // Act
            var result = controller.Latest();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(quizzesList, okResult.Value);
        }
    }
}
