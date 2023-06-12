using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UkwWypozyczalnia.DAL;

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
    }
}
