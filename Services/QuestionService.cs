using Dissertation.Context;
using Dissertation.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly QuestionsDBContext _questionsDBContext;

        public QuestionService(QuestionsDBContext questionsDBContext)
        {
            _questionsDBContext = questionsDBContext;
        }

        public List<Question> GetAllQuestions()
        {
            return _questionsDBContext.Questions.ToList();
        }
    }
}
