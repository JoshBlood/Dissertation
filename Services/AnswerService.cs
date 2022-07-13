using Dissertation.Context;
using Dissertation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IQuestionService _questionService;
        private readonly ScoreDBContext _scoreDBContext;


        public AnswerService(IQuestionService questionService, ScoreDBContext scoreDBContext)
        {
            _questionService = questionService;
            _scoreDBContext = scoreDBContext;
        }
        public int CalculateAnswer(Answers answer, int userId)
        {
            var totalScore = 0;
            var questions = _questionService.GetAllQuestions().Where(q => answer.TestAnswers.Any(a => a.QuestionId == q.QuestionsId));
            var correctAnswers = questions.Where(q => answer.TestAnswers.Any(a => q.QuestionsId == a.QuestionId && q.Answer == a.Option));
            totalScore = correctAnswers.Count();
            _scoreDBContext.Scores.Add(new Score
            {
                TestId = answer.TestId,
                Scores = totalScore,
                UserId = userId,
                TotalQuestions = questions.Count()
            });
            _scoreDBContext.SaveChanges();
            return totalScore;
        }
    }
}
