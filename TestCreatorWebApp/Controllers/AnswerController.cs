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
    public class AnswerController : ControllerBase
    {
        public List<Answer> Objects(int num, int questionId)
        {
            var answers = new List<Answer>();

            // add sample answers
            for (int i = 0; i < num; i++)
            {
                answers.Add(new Answer
                {
                    AnswerId = i + 1,
                    QuestionId = questionId,
                    Text = "jakis przykladowy tekst",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            return answers;
        }

        [HttpGet("{answerId}")]
        public IActionResult Get(int answerId)
        {
            return Content("todo");
        }

        [HttpPost]
        public IActionResult Post(AnswerDto answerDto)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Put(AnswerDto answerDto)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{answerId}")]
        public IActionResult Delete(int answerId)
        {
            throw new NotImplementedException();
        }

        // GET api/answers/all/{questionId}
        [HttpGet("all/{questionId}")]
        public string All(int questionId)
        {
            var answers = Objects(5, questionId);

            // send data as json
            return JsonConvert.SerializeObject(answers, Formatting.Indented);
        }
    }
}
