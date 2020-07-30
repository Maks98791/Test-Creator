using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TestCreatorWebApp.Controllers;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Services;
using Xunit;

namespace UnitTest_xUnit.Controllers
{
    public class QuestionControllerTests
    {
        [Fact]
        public void Get_ReturnsQuestion()
        {
            // Arrange
            var questionId = 10;
            var question = new Question{QuestionId = questionId};
            var mockService = new Mock<IQuestionService>();
            mockService.Setup(service => service.GetById(questionId))
                .Returns(question);
            var controller = new QuestionController(null, mockService.Object);

            // Act
            var result = controller.Get(questionId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(question, okResult.Value);
        }

        [Fact]
        public void Get_ReturnsHttpNotFound_WhenQuestionIsNull()
        {
            // Arrange
            var questionId = 1000;
            var mockService = new Mock<IQuestionService>();
            mockService.Setup(service => service.GetById(questionId))
                .Returns((Question)null);
            var controller = new QuestionController(null, mockService.Object);

            // Act
            var result = controller.Get(questionId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("question not found", notFoundObjectResult.Value);
        }
    }
}
