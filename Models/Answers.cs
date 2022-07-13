using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Models
{
    public class Answers
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        public List<Answer> TestAnswers { get; set; }

    }
}
