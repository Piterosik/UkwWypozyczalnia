using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UkwWypozyczalnia.DAL;
using UkwWypozyczalnia.Infrastructure;
using UkwWypozyczalnia.Models;

namespace UkwWypozyczalnia.Controllers
{
	public class CartController : Controller
	{
		FilmsContext _db;

		public CartController(FilmsContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			var cart = SessionHelper.GetObjFromJSON<List<CartItem>>(HttpContext.Session, Consts.CartKey);
			if (cart != null)
			{
				ViewBag.totalPrice = cart.Sum(x => x.Price);
			}
			return View(cart);
		}

		public IActionResult Buy(int id)
		{
			Film film = _db.Films.Find(id);

			Console.WriteLine(id);

			if (SessionHelper.GetObjFromJSON<List<CartItem>>(HttpContext.Session, Consts.CartKey) == null)
			{
				var cart = new List<CartItem>
				{
					new CartItem()
					{
						Film = film,
						Quantity = 1,
						Price = film.Price,
					}
				};
				SessionHelper.SetObjAsJSON(HttpContext.Session, Consts.CartKey, cart);
			}
			else
			{
				var cart = SessionHelper.GetObjFromJSON<List<CartItem>>(HttpContext.Session, Consts.CartKey);

				var index = cart.FindIndex(x => x.Film.Id == id);
				if (index == -1)
				{
					cart.Add(
					new CartItem()
					{
						Film = film,
						Quantity = 1,
						Price = film.Price,
					});
				}
				else
				{
					cart[index].Quantity++;
					cart[index].Price += film.Price;
				}
				SessionHelper.SetObjAsJSON(HttpContext.Session, Consts.CartKey, cart);
			}

			return RedirectToAction("Index");
		}

		public IActionResult Remove(int id)
		{
			var items = SessionHelper.GetObjFromJSON<List<CartItem>>(HttpContext.Session, Consts.CartKey);

			var itemToDelete = items.Find(x => x.Film.Id == id);
			if (itemToDelete != null)
			{
				if (itemToDelete.Quantity > 1)
				{
					itemToDelete.Quantity--;
					itemToDelete.Price -= itemToDelete.Film.Price;
				}
				else
				{
					items.Remove(itemToDelete);
				}
				SessionHelper.SetObjAsJSON(HttpContext.Session, Consts.CartKey, items);
			}

			return RedirectToAction("Index");
		}
	}
}
