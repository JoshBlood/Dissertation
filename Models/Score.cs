using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        public int TestId { get; set; }
        public int Scores { get; set; }
        public int UserId { get; set; }
        public int TotalQuestions { get; set; }
        public string Result { get; set; }
    }
}
