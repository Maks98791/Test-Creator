using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCreatorWebApp.Db;
using TestCreatorWebApp.Db.Models;

namespace TestCreatorWebApp.Services
{
    public class QuizService : IQuizService
    {
        private readonly TestCreatorContext _context;

        public QuizService(TestCreatorContext context)
        {
            _context = context;
        }

        public Quiz GetById(int quizId)
        {
            return _context.Quizzes.FirstOrDefault(q => q.QuizId == quizId);
        }

        public List<Quiz> GetLatest(int num)
        {
            return _context.Quizzes
                .OrderByDescending(q => q.CreatedDate)
                .Take(num)
                .ToList();
        }

        public List<Quiz> GetRandom(int num)
        {
            return _context.Quizzes
                .OrderBy(q => Guid.NewGuid())
                .Take(num)
                .ToList();
        }

        public List<Quiz> GetByTitle(int num)
        {
            return _context.Quizzes
                .OrderBy(q => q.Title)
                .Take(num)
                .ToList();
        }
    }
}
