using System.Collections.Generic;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Dtos;

namespace TestCreatorWebApp.Services
{
    public interface IQuestionService
    {
        public Question GetById(int questionId);
        public List<Question> GetAll(int quizId);
        public Question Add(QuestionDto questionDto);
        public Question Update(QuestionDto questionDto);
        public void Delete(int questionId);
    }
}