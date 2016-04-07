using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poller.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public int PollID { get; set; }
        public string AnswerString { get; set; }
        public int Votes { get; set; }
    }
}
