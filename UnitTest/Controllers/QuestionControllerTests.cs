using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TestCreatorWebApp.Controllers;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Dtos;
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
            var controller = new QuestionController(null, mockService.Object);

            // Act
            var result = controller.Get(questionId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("question not found", notFoundObjectResult.Value);
        }

        [Fact]
        public void Post_ReturnsQuestionFromModel_WhenQuestionIdIsCorrect()
        {
            // Arrange
            var mockService = new Mock<IQuestionService>();
            var controller = new QuestionController(null, mockService.Object);
            var model = new QuestionDto();
            var question = new Question();
            mockService.Setup(service => service.Add(model))
                .Returns(question);

            // Act
            var result = controller.Post(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(question, okResult.Value);
        }

        [Fact]
        public void Post_ReturnsHttpBadRequest_WhenQuestionModelIsNull()
        {
            // Arrange
            var mockService = new Mock<IQuestionService>();
            var controller = new QuestionController(null, mockService.Object);

            // Act
            var result = controller.Post(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("bad model", badRequestResult.Value);
        }


        [Fact]
        public void Put_ReturnsQuestion_WhenModelIsCorrect()
        {
            // Arrange
            var mockService = new Mock<IQuestionService>();
            var controller = new QuestionController(null, mockService.Object);
            var model = new QuestionDto();
            var question = new Question();
            mockService.Setup(service => service.Update(model))
                .Returns(question);

            // Act
            var result = controller.Put(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(question, okResult.Value);
        }

        [Fact]
        public void Put_ReturnsHttpBadRequest_WhenQuestionModelIsNull()
        {
            // Arrange
            var mockService = new Mock<IQuestionService>();
            var controller = new QuestionController(null, mockService.Object);

            // Act
            var result = controller.Put(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("bad model", badRequestResult.Value);
        }

        [Fact]
        public void Delete_ReturnHttpNotFound_WhenQuestionIsNull()
        {
            // Arrange
            var questionId = 10;
            var mockService = new Mock<IQuestionService>();
            var controller = new QuestionController(null, mockService.Object);
            mockService.Setup(service => service.GetById(questionId))
                .Returns((Question)null);

            // Act
            var result = controller.Delete(questionId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("question not found", notFoundResult.Value);
        }

        [Fact]
        public void Delete_ReturnsHttpNoContent_WhenQuestionIdIsCorrect()
        {
            // Arrange
            var questionId = 1;
            var mockService = new Mock<IQuestionService>();
            var controller = new QuestionController(null, mockService.Object);
            mockService.Setup(service => service.GetById(questionId))
                .Returns(new Question());

            // Act
            var result = controller.Delete(questionId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void All_ReturnsQuestionList_WhenQuizIdIsCorrect()
        {
            // Arrange
            var quizId = 1;
            var questionList = new List<Question>();
            var mockQuestionService = new Mock<IQuestionService>();
            var mockQuizService = new Mock<IQuizService>();
            var controller = new QuestionController(mockQuizService.Object, mockQuestionService.Object);
            mockQuizService.Setup(quizService => quizService.GetById(quizId))
                .Returns(new Quiz());
            mockQuestionService.Setup(questionService => questionService.GetAll(quizId))
                .Returns(questionList);

            // Act
            var result = controller.All(quizId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(questionList, okResult.Value);
        }

        [Fact]
        public void All_ReturnsHttpNotFound_WhenQuizIsNull()
        {
            // Arrange
            var quizId = 1;
            var mockService = new Mock<IQuizService>();
            var controller = new QuestionController(mockService.Object, null);
            mockService.Setup(service => service.GetById(quizId))
                .Returns((Quiz)null);

            // Act
            var result = controller.All(quizId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("quiz not found", notFoundObjectResult.Value);
        }
    }
}
