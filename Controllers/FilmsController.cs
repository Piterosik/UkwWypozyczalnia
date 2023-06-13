using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UkwWypozyczalnia.DAL;
using UkwWypozyczalnia.Models;
using UkwWypozyczalnia.ViewModels;

namespace UkwWypozyczalnia.Controllers
{
    public class FilmsController : Controller
    {
        private FilmsContext _db;

        public FilmsController(FilmsContext db)
        {
            _db = db;
        }

        public IActionResult FilmsList(string categoryName)
        {
            var category = _db.Categories.Include("Films").Where(x => x.Name.ToUpper() == categoryName.ToUpper()).Single();
            var films = category.Films.ToList();
            return View(films);
        }

        [HttpGet]
        public IActionResult AddFilm()
        {
            var model = new AddFilmViewModel();
            var categories = _db.Categories.ToList();

            model.Categories = categories;

            return View(model);
        }

        [HttpPost]
        public IActionResult AddFilm(AddFilmViewModel model)
        {
            _db.Films.Add(model.Film);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditFilm(int id)
        {
            var film = _db.Films.Where(x => x.Id == id).FirstOrDefault();

            return View(film);
        }

        [HttpPost]
        public IActionResult EditFilm(Film film)
        {
            var dbFilm = _db.Films.Where(x => x.Id == film.Id).FirstOrDefault();

            dbFilm.Title = film.Title;
            dbFilm.Director = film.Director;
            dbFilm.Price = film.Price;
            dbFilm.CategoryId = film.CategoryId;

            _db.Entry(dbFilm).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("ListFilms", "Films");
        }




    }
}
