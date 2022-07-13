using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Models
{
    public class Test
    {
       [Key]
       public int TestId { get; set; }
       public int QuestionsId { get; set; }
       public int TotalScoreAmount { get; set; }
       public int UserId { get; set; }

    }
}
