using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCreatorWebApp.Db.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string Text { get; set; }
        public string Notes { get; set; }
        public int Type { get; set; }
        public int Flags { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
