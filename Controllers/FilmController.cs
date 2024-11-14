using Microsoft.AspNetCore.Mvc;
using CRUD.Models;
using System.Collections.Generic;
using System.Linq;
using CRUD.Models;

namespace FilmyApp.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film { Id = 1, Name = "Film1", Description = "Opis filmu 1", Price = 3 },
            new Film { Id = 2, Name = "Film2", Description = "Opis filmu 2", Price = 5 },
            new Film { Id = 3, Name = "Film3", Description = "Opis filmu 3", Price = 3 }
        };

        public IActionResult Index()
        {
            return View(films);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var film = films.FirstOrDefault(f => f.Id == id);
            return View(film);
        }

        public IActionResult Edit(int id)
        {
            var film = films.FirstOrDefault(f => f.Id == id);
            return View(film);
        }

        public IActionResult Edit(Film updatedFilm)
        {
            var film = films.FirstOrDefault(f => f.Id == updatedFilm.Id);
            if (film != null)
            {
                film.Name = updatedFilm.Name;
                film.Description = updatedFilm.Description;
                film.Price = updatedFilm.Price;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(f => f.Id == id);
            if (film != null)
            {
                films.Remove(film);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
