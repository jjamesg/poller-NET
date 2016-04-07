using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poller.Models
{
    public class Poll
    {
        public int PollID { get; set; }
        public string Question { get; set; }
        public string User { get; set; }
    }
}

