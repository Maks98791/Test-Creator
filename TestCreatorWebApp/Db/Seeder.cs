using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestCreatorWebApp.Db.Models;

namespace TestCreatorWebApp.Db
{
    public class Seeder
    {
        public static void Seed(TestCreatorContext context)
        {
            // if there are no users - create some
            if (!context.Users.Any())
            {
                CreateUsers(context);
            }

            // if there are no quizzes - create default with answers and questions
            if (!context.Quizzes.Any())
            {
                CreateQuizzes(context);
            }
        }

        private static void CreateQuizzes(TestCreatorContext context)
        {
            DateTime createdDate = new DateTime(2020, 5, 12, 4, 46, 44);
            DateTime lastModifiedDate = DateTime.Now;

            var authorId = context.Users.FirstOrDefault(u => u.Name == "Admin").UserId;

            for (var i = 1; i <= 50; i++)
            {
                CreateSampleQuiz(context, i, authorId, 51 - i, 3, 3, 3, createdDate.AddDays(-51));
            }

            EntityEntry<Quiz> e1 = context.Quizzes.Add(new Quiz()
            {
                UserId = authorId,
                Title = "Where does it come from?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry",
                Text = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",
                ViewCount = 233,
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            });

            EntityEntry<Quiz> e2 = context.Quizzes.Add(new Quiz()
            {
                UserId = authorId,
                Title = "Why do we use it?",
                Description = "Many desktop publishing packages and web page",
                Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using Content here, content here",
                ViewCount = 4543,
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            });

            EntityEntry<Quiz> e3 = context.Quizzes.Add(new Quiz()
            {
                UserId = authorId,
                Title = "Where can I get some?",
                Description = "The Extremes of Good and Evil) by Cicero, written in 45 BC",
                Text = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites",
                ViewCount = 33,
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            });

            context.SaveChanges();
        }

        private static void CreateUsers(TestCreatorContext context)
        {
            DateTime createdDate = new DateTime(2020, 3, 14, 11, 34, 22);
            DateTime lastModifiedDate = DateTime.Now;

            var adminUser = new User()
            {
                Name = "Admin",
                Email = "admin@gmail.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            context.Users.Add(adminUser);

            var firstUser = new User()
            {
                Name = "Michael",
                Email = "michael@gmail.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            var secondUser = new User()
            {
                Name = "Sophie",
                Email = "sophie@gmail.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            var thirdUser = new User()
            {
                Name = "Ann",
                Email = "ann@gmail.com",
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            context.Users.AddRange(firstUser, secondUser, thirdUser);

            context.SaveChanges();
        }

        private static void CreateSampleQuiz(TestCreatorContext context, int num, int authorId, int viewCount, int questionsNumber, int answersNumber, int resultsNumber, DateTime createdDate)
        {
            var quiz = new Quiz()
            {
                UserId = authorId,
                Title = String.Format("Tytul quizu {0}", num),
                Description = String.Format("Przykladowy opis quizu {0}", num),
                Text = "Przykładowy quiz utworzony w celach testowych",
                ViewCount = viewCount,
                CreatedDate = createdDate,
                LastModifiedDate = createdDate
            };

            context.Quizzes.Add(quiz);
            context.SaveChanges();

            for (var i = 0; i < questionsNumber; i++)
            {
                var question = new Question()
                {
                    QuizId = quiz.QuizId,
                    Text = "Przykładowe pytanie utworzone w celach testowych",
                    CreatedDate = createdDate,
                    LastModifiedDate = createdDate
                };

                context.Questions.Add(question);
                context.SaveChanges();

                for (var j = 0; j < answersNumber; j++)
                {
                    var e2 = context.Answers.Add(new Answer()
                    {
                        QuestionId = question.QuestionId,
                        Text = "Przykładowa odpowiedz utworzona w celach testowych",
                        Value = j,
                        CreatedDate = createdDate,
                        LastModifiedDate = createdDate
                    });
                }
            }

            for (var a = 0; a < resultsNumber; a++)
            {
                context.Results.Add(new Result()
                {
                    QuizId = quiz.QuizId,
                    Text = "Przykładowy wynik utworzony w celach testowych",
                    MinValue = 0,
                    MaxValue = 0,
                    CreatedDate = createdDate,
                    LastModifiedDate = createdDate
                });
            }

            context.SaveChanges();
        }
    }
}
