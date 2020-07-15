using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestCreatorWebApp.Db.Models;
using TestCreatorWebApp.Dtos;

namespace TestCreatorWebApp.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<QuizDto, Quiz>();
            CreateMap<UserDto, User>();
            CreateMap<AnswerDto, Answer>();
            CreateMap<QuestionDto, Question>();
            CreateMap<ResultDto, Result>();
        }
    }
}
