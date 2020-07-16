using System.Collections.Generic;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Dtos;

namespace TestCreatorWebApp.Services
{
    public interface IResultService
    {
        public Result GetById(int resultId);
        public List<Result> GetAll(int quizId);
        public Result Add(ResultDto resultDto);
        public Result Update(ResultDto resultDto);
        public void Delete(int resultId);
    }
}