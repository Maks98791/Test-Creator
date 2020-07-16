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
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        private readonly IQuizService _quizService;

        public ResultController(IResultService resultService, IQuizService quizService)
        {
            _resultService = resultService;
            _quizService = quizService;
        }

        [HttpGet("{resultId}")]
        public IActionResult Get(int resultId)
        {
            var result = _resultService.GetById(resultId);

            if (result == null)
            {
                return NotFound("result not found");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ResultDto resultDto)
        {
            if (resultDto == null)
            {
                return BadRequest();
            }

            var result = _resultService.Add(resultDto);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Put([FromBody] ResultDto resultDto)
        {
            if (resultDto == null)
            {
                return BadRequest();
            }

            var result = _resultService.Update(resultDto);

            return Ok(result);
        }

        [HttpGet("{resultId}")]
        public IActionResult Delete(int resultId)
        {
            var result = _resultService.GetById(resultId);

            if (result == null)
            {
                return NotFound("result not found");
            }

            _resultService.Delete(resultId);

            return NoContent();
        }

        // GET api/results/all/{quizId}
        [HttpGet("all/{quizId}")]
        public IActionResult All(int quizId)
        {
            var quiz = _quizService.GetById(quizId);

            if (quiz == null)
            {
                return NotFound("quiz not found");
            }

            var results = _resultService.GetAll(quizId);

            return Ok(results);
        }
    }
}
