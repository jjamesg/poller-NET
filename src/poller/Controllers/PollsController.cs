using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using poller.Models;
using poller.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;


namespace poller.Controllers
{
    public class PollsController : Controller
    {
        private ApplicationDbContext _context;

        public PollsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Polls/Results/5
        public IActionResult Results(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Poll poll = _context.Poll.Single(m => m.PollID == id);
            if (poll == null)
            {
                return HttpNotFound();
            }

            List<Answer> answers = _context.Answer.Where(a => a.PollID == id).ToList();
            PollAndAnswers pAndA = new PollAndAnswers();
            pAndA.poll = poll;
            pAndA.answers = answers;
            pAndA.TotalVotes = answers.Aggregate(0, (acc, x) => acc + x.Votes);



            return View(pAndA);
        }

        // GET: Polls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Polls/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Poll poll, List<string> answers)
        {
            if (ModelState.IsValid)
            {
                poll.User = User.Identity.Name;
                _context.Poll.Add(poll);
                _context.SaveChanges();
                
                foreach (string answer in answers)
                {
                    if (answer != null)
                    {
                        Answer _answer = new Answer();
                        _answer.PollID = poll.PollID;
                        _answer.AnswerString = answer;
                        _context.Answer.Add(_answer);
                    }
                };
                _context.SaveChanges();
                return RedirectToAction("Vote", new { id = poll.PollID });
            }

            return View(poll);
        }


        // GET: Polls/Vote/5
        public IActionResult Vote(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Poll poll = _context.Poll.Single(m => m.PollID == id);
            if (poll == null)
            {
                return HttpNotFound();
            }

            List<Answer> answers = _context.Answer.Where(a => a.PollID == id).ToList();
            PollAndAnswers pAndA = new PollAndAnswers();
            pAndA.answers = answers;
            pAndA.poll = poll;


            return View(pAndA);
        }

        // POST: Polls/Vote/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Vote(int id, int answerID)
        {
            if (ModelState.IsValid)
            {
                Answer answer =_context.Answer.Single(a => a.AnswerID == answerID);
                answer.Votes++;
                _context.Update(answer);
                _context.SaveChanges();
                return RedirectToAction("Results", new { id = id });
            }
            return View();
        }

        // GET: Polls/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Poll poll = _context.Poll.Single(m => m.PollID == id);
            if (poll == null)
            {
                return HttpNotFound();
            }

            return View(poll);
        }

        // POST: Polls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Poll poll = _context.Poll.Single(m => m.PollID == id);
            _context.Poll.Remove(poll);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
