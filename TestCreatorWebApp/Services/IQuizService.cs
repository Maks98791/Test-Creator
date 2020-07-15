using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Dtos;

namespace TestCreatorWebApp.Services
{
    public interface IQuizService
    {
        public Quiz GetById(int quizId);
        public List<Quiz> GetLatest(int num);
        public List<Quiz> GetRandom(int num);
        public List<Quiz> GetByTitle(int num);
        public Quiz Add(QuizDto quizDto);
        public Quiz Update(QuizDto quizDto);
        public void Delete(int quizId);
    }
}
