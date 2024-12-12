using Microsoft.AspNetCore.Mvc;
using TestWithADO.Models;
using TestWithADO.Services;

namespace TestWithADO.Controllers
{
    public class PersonneController : Controller
    {
        private readonly PersonneService _personneService;

        public PersonneController(PersonneService personneService)
        {
            _personneService = personneService;
        }

        // Afficher la liste des personnes
        public IActionResult Index()
        {
            var personnes = _personneService.GetAllPersonnes();
            return View(personnes);
        }

        // Afficher le formulaire pour ajouter une personne
        public IActionResult Create()
        {
            return View();
        }

        // Ajouter une personne
        [HttpPost]
        public IActionResult Create(Personne personne)
        {
            if (ModelState.IsValid)
            {
                _personneService.AddPersonne(personne);
                return RedirectToAction("Index");
            }
            return View(personne);
        }

        // Afficher le formulaire pour modifier une personne
        public IActionResult Edit(int id)
        {
            var personne = _personneService.GetAllPersonnes().Find(p => p.PersonneID == id);
            if (personne == null)
            {
                return NotFound();
            }
            return View(personne);
        }

        // Modifier une personne
        [HttpPost]
        public IActionResult Edit(Personne personne)
        {
            if (ModelState.IsValid)
            {
                _personneService.UpdatePersonne(personne);
                return RedirectToAction("Index");
            }
            return View(personne);
        }

        // Supprimer une personne
        public IActionResult Delete(int id)
        {
            var personne = _personneService.GetAllPersonnes().Find(p => p.PersonneID == id);
            if (personne == null)
            {
                return NotFound();
            }
            _personneService.DeletePersonne(id);
            return RedirectToAction("Index");
        }
    }
}
