using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UkwWypozyczalnia.DAL;

namespace UkwWypozyczalnia.Controllers
{
    public class HomeController : Controller
    {
        private FilmsContext _db;

        public HomeController(FilmsContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StaticSite(string name)
        {
            return View(name);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //  public IActionResult Error()
        //    {
        //          return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //        }
    }
}
