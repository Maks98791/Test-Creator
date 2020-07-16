using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestCreatorWebApp.Db;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Dtos;

namespace TestCreatorWebApp.Services
{
    public class QuizService : IQuizService
    {
        private readonly TestCreatorContext _context;
        private readonly IMapper _mapper;

        public QuizService(TestCreatorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public Quiz Add(QuizDto quizDto)
        {
            var quiz = _mapper.Map<Quiz>(quizDto);

            if (quiz.UserId == 0)
            {
                quiz.UserId = _context.Users.FirstOrDefault(u => u.Name == "Admin").UserId;
            }

            _context.Add(quiz);
            _context.SaveChanges();

            return quiz;
        }

        public Quiz Update(QuizDto quizDto)
        {
            var quiz = _mapper.Map<Quiz>(quizDto);

            if (quiz.UserId == 0)
            {
                quiz.UserId = _context.Users.FirstOrDefault(u => u.Name == "Admin").UserId;
            }

            _context.Update(quiz);
            _context.SaveChanges();

            return quiz;
        }

        public void Delete(int quizId)
        {
            var quiz = GetById(quizId);

            _context.Quizzes.Remove(quiz);
            _context.SaveChanges();
        }
    }
}
