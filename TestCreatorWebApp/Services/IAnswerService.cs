using System.Collections.Generic;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Dtos;

namespace TestCreatorWebApp.Services
{
    public interface IAnswerService
    {
        public Answer GetById(int answerId);
        public List<Answer> GetAll(int questionId);
        public Answer Add(AnswerDto answerDto);
        public Answer Update(AnswerDto answerDto);
        public void Delete(int answerId);
    }
}