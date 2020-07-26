using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Dtos;
using TestCreatorWebApp.Services;

namespace TestCreatorWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly IQuestionService _questionService;

        public QuestionController(IQuizService quizService, IQuestionService questionService)
        {
            _quizService = quizService;
            _questionService = questionService;
        }

        [HttpGet("{questionId}")]
        public IActionResult Get(int questionId)
        {
            var question = _questionService.GetById(questionId);

            if (question == null)
            {
                return NotFound("question not found");
            }

            return Ok(question);
        }

        [HttpPost]
        public IActionResult Post([FromBody] QuestionDto questionDto)
        {
            if (questionDto == null)
            {
                return BadRequest("bad model");
            }

            var question = _questionService.Add(questionDto);

            return Ok(question);
        }

        [HttpPut]
        public IActionResult Put([FromBody] QuestionDto questionDto)
        {
            if (questionDto == null)
            {
                return BadRequest("bad model");
            }

            var question = _questionService.Update(questionDto);

            return Ok(question);
        }

        [HttpDelete("{questionId}")]
        public IActionResult Delete(int questionId)
        {
            var question = _questionService.GetById(questionId);

            if (question == null)
            {
                return NotFound("question not found");
            }

            _questionService.Delete(questionId);

            return NoContent();
        }

        // GET api/question/all/{quizId}
        [HttpGet("all/{quizId}")]
        public IActionResult All(int quizId)
        {
            var quiz = _quizService.GetById(quizId);

            if (quiz == null)
            {
                return NotFound("quiz not found");
            }

            var questions = _questionService.GetAll(quizId);

            return Ok(questions);
        }
    }
}
