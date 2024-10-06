using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAVoting.Migrations;
using ProjectAVoting.Models;
using System.Diagnostics;

namespace ProjectAVoting.Controllers
{
    public class HomeController : Controller
    {
        public class VotePersonViewModel
        {
            public IEnumerable<VoteOption> Votes { get; set; }
            public Person NewPerson { get; set; }


        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            VoteContext Context = new VoteContext();

            var viewModel = new VotePersonViewModel
            {
                Votes = Context.VoteOptions.ToList(),
                NewPerson = new Person(),
            }; 
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(VotePersonViewModel viewModel)
        {
            VoteContext Context = new VoteContext();
            if (ModelState.IsValid)
            {
                Context.persons.Add(viewModel.NewPerson);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            viewModel.Votes = Context.VoteOptions.ToList();

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
