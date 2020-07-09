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
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TestCreatorWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        public List<Quiz> Objects(int num)
        {
            var quizzes = new List<Quiz>();

            // add sample quizzes
            for (int i = 0; i < num; i++)
            {
                quizzes.Add(new Quiz
                {
                    QuizId = i + 1,
                    Title = "jakis przykladowy tekst",
                    Description = String.Format("dupa dupa dupa {0}", i + 1),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            return quizzes;
        }

        // GET api/quiz/{quizId}
        [HttpGet("{quizId}")]
        public string Get(int quizId)
        {
            var quizzes = Objects(10);
            var quiz = quizzes.FirstOrDefault(q => q.QuizId == quizId);

            // send data as json
            return JsonConvert.SerializeObject(quiz, Formatting.Indented);
        }

        [HttpPost]
        public IActionResult Post(QuizDto quizDto)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Put(QuizDto quizDto)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{quizId}")]
        public IActionResult Delete(int quizId)
        {
            throw new NotImplementedException();
        }

        // GET api/quiz/Latest
        [HttpGet("Latest/{num?}")]
        public string Latest(int num = 10)
        {
            var quizzes = Objects(num);

            // send data as json
            return JsonConvert.SerializeObject(quizzes, Formatting.Indented);
        }

        // GET api/quiz/ByTitle/{num?}
        [HttpGet("ByTitle/{num:int?}")]
        public string ByTitle(int num = 10)
        {
            var quizzes = Objects(num);

            // send data as json
            return JsonConvert.SerializeObject(quizzes.OrderBy(t => t.Title), Formatting.Indented);
        }

        // GET api/quiz/Random/{num?}
        [HttpGet("Random/{num:int?}")]
        public string Random(int num = 10)
        {
            var quizzes = Objects(num);

            // send data as json
            return JsonConvert.SerializeObject(quizzes.OrderBy(n => Guid.NewGuid()), Formatting.Indented);
        }
    }
}
