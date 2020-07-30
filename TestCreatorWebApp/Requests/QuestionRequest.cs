using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCreatorWebApp.Dtos;

namespace TestCreatorWebApp.Requests
{
    public class QuestionRequest
    {
        public QuestionDto QuestionDto { get; set; }
        public int QuizId { get; set; }
    }
}
