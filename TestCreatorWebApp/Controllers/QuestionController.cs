using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Dtos;

namespace TestCreatorWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public List<Question> Objects(int num, int quizId)
        {
            var questions = new List<Question>();

            // add sample questions
            for (int i = 0; i < num; i++)
            {
                questions.Add(new Question
                {
                    QuestionId = i+1,
                    QuizId = quizId,
                    Text = "jakis przykladowy tekst",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            return questions;
        }

        [HttpGet("{questionId}")]
        public IActionResult Get(int questionId)
        {
            return Content("todo");
        }

        [HttpPost]
        public IActionResult Post(QuestionDto questionDto)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Put(QuestionDto questionDto)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{questionId}")]
        public IActionResult Delete(int questionId)
        {
            throw new NotImplementedException();
        }

        // GET api/question/all/{quizId}
        [HttpGet("all/{quizId}")]
        public string All(int quizId)
        {
            var questions = Objects(5, quizId);

            // send data as json
            return JsonConvert.SerializeObject(questions, Formatting.Indented);
        }
    }
}
