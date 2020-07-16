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
    public class ResultService : IResultService
    {
        private readonly TestCreatorContext _context;
        private readonly IMapper _mapper;

        public ResultService(TestCreatorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result Add(ResultDto resultDto)
        {
            var result = _mapper.Map<Result>(resultDto);

            _context.Results.Add(result);
            _context.SaveChanges();

            return result;
        }

        public void Delete(int resultId)
        {
            var result = GetById(resultId);

            _context.Results.Remove(result);
            _context.SaveChanges();
        }

        public List<Result> GetAll(int quizId)
        {
            return _context.Results.Where(r => r.QuizId == quizId).ToList();
        }

        public Result GetById(int resultId)
        {
            return _context.Results.FirstOrDefault(r => r.ResultId == resultId);
        }

        public Result Update(ResultDto resultDto)
        {
            var result = _mapper.Map<Result>(resultDto);

            _context.Results.Update(result);
            _context.SaveChanges();

            return result;
        }
    }
}
