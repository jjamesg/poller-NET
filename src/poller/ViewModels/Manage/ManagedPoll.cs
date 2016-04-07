using System.Collections.Generic;
using poller.Models;

namespace poller.ViewModels.Manage
{
    public class ManagedPoll
    {
        public int PollID { get; set; }

        public string Question { get; set; }

        public List<Answer> Answers { get; set; }

        public int Votes { get; set; }
    }
}
