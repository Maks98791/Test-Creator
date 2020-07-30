using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCreatorWebApp.Dtos;

namespace TestCreatorWebApp.Requests
{
    public class ResultRequest
    {
        public ResultDto ResultDto { get; set; }
        public int QuizId { get; set; }
    }
}
