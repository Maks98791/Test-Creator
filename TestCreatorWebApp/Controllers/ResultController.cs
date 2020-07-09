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
    public class ResultController : ControllerBase
    {
        public List<Result> Objects(int num, int quizId)
        {
            var results = new List<Result>();

            // add sample results
            for (int i = 0; i < num; i++)
            {
                results.Add(new Result
                {
                    ResultId = i + 1,
                    QuizId = quizId,
                    Text = "jakis przykladowy tekst",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            return results;
        }

        [HttpGet("{resultId}")]
        public IActionResult Get(int resultId)
        {
            return Content("todo");
        }

        [HttpPost]
        public IActionResult Post(ResultDto resultDto)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Put(ResultDto resultDto)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{resultId}")]
        public IActionResult Delete(int resultId)
        {
            throw new NotImplementedException();
        }

        // GET api/results/all/{quizId}
        [HttpGet("all/{quizId}")]
        public string All(int quizId)
        {
            var results = Objects(5, quizId);

            // send data as json
            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }
    }
}
