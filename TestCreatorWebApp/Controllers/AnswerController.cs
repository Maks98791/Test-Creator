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
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;

        public AnswerController(IAnswerService answerService, IQuestionService questionService)
        {
            _answerService = answerService;
            _questionService = questionService;
        }

        [HttpGet("{answerId}")]
        public IActionResult Get(int answerId)
        {
            var answer = _answerService.GetById(answerId);

            if (answer == null)
            {
                return NotFound("answer not found");
            }

            return Ok(answer);
        }

        [HttpPost]
        public IActionResult Post(AnswerDto answerDto)
        {
            if (answerDto == null)
            {
                return BadRequest("bad model");
            }

            var answer = _answerService.Add(answerDto);

            return Ok(answer);
        }

        [HttpPost]
        public IActionResult Put(AnswerDto answerDto)
        {
            if (answerDto == null)
            {
                return BadRequest("bad model");
            }

            var answer = _answerService.Update(answerDto);

            return Ok(answer);
        }

        [HttpGet("{answerId}")]
        public IActionResult Delete(int answerId)
        {
            var answer = _answerService.GetById(answerId);

            if (answer == null)
            {
                return NotFound("answer not found");
            }

            _answerService.Delete(answerId);

            return NoContent();
        }

        // GET api/answers/all/{questionId}
        [HttpGet("all/{questionId}")]
        public IActionResult All(int questionId)
        {
            var question = _questionService.GetById(questionId);

            if (question == null)
            {
                return NotFound("question not found");
            }

            var answers = _answerService.GetAll(questionId);

            return Ok(answers);
        }
    }
}
