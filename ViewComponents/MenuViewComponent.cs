using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UkwWypozyczalnia.DAL;

namespace UkwWypozyczalnia.ViewComponents
{
	public class MenuViewComponent : ViewComponent
	{
		FilmsContext _db;

		public MenuViewComponent(FilmsContext db)
		{
			_db = db;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return await Task.FromResult((IViewComponentResult) View("_Menu", _db.Categories.ToList()));
		}
	}
}
