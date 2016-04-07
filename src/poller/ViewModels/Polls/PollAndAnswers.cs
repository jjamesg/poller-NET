using poller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poller.ViewModels
{
    public class PollAndAnswers
    {
        public Poll poll { get; set; }
        public List<Answer> answers { get; set; }
        public int TotalVotes { get; set; }
    }
}
