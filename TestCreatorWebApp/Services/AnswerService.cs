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
    public class AnswerService : IAnswerService
    {
        private readonly TestCreatorContext _context;
        private readonly IMapper _mapper;

        public AnswerService(TestCreatorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Answer Add(AnswerDto answerDto)
        {
            var answer = _mapper.Map<Answer>(answerDto);

            _context.Answers.Add(answer);
            _context.SaveChanges();

            return answer;
        }

        public void Delete(int answerId)
        {
            var answer = GetById(answerId);

            _context.Answers.Remove(answer);
            _context.SaveChanges();
        }

        public List<Answer> GetAll(int questionId)
        {
            return _context.Answers.Where(a => a.QuestionId == questionId).ToList();
        }

        public Answer GetById(int answerId)
        {
            return _context.Answers.FirstOrDefault(a => a.AnswerId == answerId);
        }

        public Answer Update(AnswerDto answerDto)
        {
            var answer = _mapper.Map<Answer>(answerDto);

            _context.Answers.Update(answer);
            _context.SaveChanges();

            return answer;
        }
    }
}
