using Microsoft.AspNetCore.Mvc;
using ProjectAVoting.Bl;
using ProjectAVoting.Models;

namespace ProjectAVoting.Areas.admin.Controllers
{
    [Area("admin")]
    public class VoteController : Controller
    {
        Votes votes = new Votes();
        public IActionResult List()
        {

            return View(votes.GetAll());
        }
        public IActionResult Edit(int? Id)
        {
            var vote = new VoteOption();
            if (Id != null)
            {
                vote = votes.GetById(Convert.ToInt32(Id));
            }
            return View(vote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(VoteOption vote)
        {

            if (!ModelState.IsValid)
                return View("Edit", vote);
            votes.Save(vote);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            votes.Delete(Id);
            return RedirectToAction("List");

        }
        
    }
}
