using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCreatorWebApp.Dtos;

namespace TestCreatorWebApp.Requests
{
    public class AnswerRequest
    {
        public AnswerDto AnswerDto { get; set; }
        public int QuestionId { get; set; }
    }
}
