using Microsoft.AspNetCore.Mvc;
using ProjectAVoting.Bl;
using ProjectAVoting.Models;

namespace ProjectAVoting.Areas.admin.Controllers
{
    [Area("admin")]
    public class PersonController : Controller
    {
        Persons person = new Persons();
        public IActionResult List()
        {

            return View(person.GetAll());
        }
        public IActionResult Details(int id)
        {
              var  persons = person.GetById(id);
            return View(persons);
        }
        public IActionResult Edit(int Id)
        {
            var persons = person.GetById(Id);
            return View(persons);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Person persons)
        {

            if (!ModelState.IsValid)
                return View("Edit", persons);
            person.Save(persons);
                
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            person.Delete(Id);
            return RedirectToAction("List");

        }
    }
}
