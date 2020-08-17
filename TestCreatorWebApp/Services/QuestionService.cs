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
    public class QuestionService : IQuestionService
    {
        private readonly TestCreatorContext _context;
        private readonly IMapper _mapper;

        public QuestionService(TestCreatorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Question Add(QuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);

            _context.Questions.Add(question);
            _context.SaveChanges();

            return question;
        }

        public void Delete(int questionId)
        {
            var question = GetById(questionId);

            _context.Questions.Remove(question);
            _context.SaveChanges();
        }

        public List<Question> GetAll(int quizId)
        {
            return _context.Questions.Where(q => q.QuizId == quizId).ToList();
        }

        public Question GetById(int questionId)
        {
            return _context.Questions.FirstOrDefault(q => q.QuestionId == questionId);
        }

        public Question Update(QuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);

            _context.Questions.Update(question);
            _context.SaveChanges();

            return question;
        }

        public List<Question> GetAllQuestions()
        {
            return _context.Questions.ToList();
        }
    }
}
