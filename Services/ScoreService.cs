using Dissertation.Context;
using Dissertation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Services
{
    public class ScoreService : IScoreService
    {
        private readonly ScoreDBContext _scoreDBContext;

        public ScoreService(ScoreDBContext scoreDBContext)
        {
            _scoreDBContext = scoreDBContext;
        }

        public List<Score> GetAllScores()
        {
            var scores = _scoreDBContext.Scores.ToList();

            foreach (var score in scores)
            {
                score.Result = $"{score.Scores}/{score.TotalQuestions}";
            }

            return _scoreDBContext.Scores.ToList();
        }
    }
}
