using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        // GET api/quiz/{quizId}
        [HttpGet("{quizId}")]
        public IActionResult Get(int quizId)
        {
            var quiz = _quizService.GetById(quizId);

            if (quiz == null)
            {
                return NotFound("quiz not found");
            }

            return Ok(quiz);
        }

        [HttpPost]
        public IActionResult Post([FromBody] QuizDto quizDto)
        {
            if (quizDto == null)
            {
                return BadRequest();
            }

            var quiz = _quizService.Add(quizDto);

            return Ok(quiz);
        }

        [HttpPut]
        public IActionResult Put([FromBody] QuizDto quizDto)
        {
            if (quizDto == null)
            {
                return BadRequest();
            }

            var quiz = _quizService.Update(quizDto);

            return Ok(quiz);
        }

        [HttpDelete("{quizId}")]
        public IActionResult Delete(int quizId)
        {
            var quiz = _quizService.GetById(quizId);

            if (quiz == null)
            {
                return NotFound("quiz not found");
            }

            _quizService.Delete(quizId);

            return NoContent();
        }

        // GET api/quiz/Latest
        [HttpGet("Latest/{num?}")]
        public IActionResult Latest(int num = 10)
        {
            var quizzes = _quizService.GetLatest(num);

            return Ok(quizzes);
        }

        // GET api/quiz/ByTitle/{num?}
        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num = 10)
        {
            var quizzes = _quizService.GetByTitle(num);

            return Ok(quizzes);
        }

        // GET api/quiz/Random/{num?}
        [HttpGet("Random/{num:int?}")]
        public IActionResult Random(int num = 10)
        {
            var quizzes = _quizService.GetRandom(num);

            return Ok(quizzes);
        }
    }
}
