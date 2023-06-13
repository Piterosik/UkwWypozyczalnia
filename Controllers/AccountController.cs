using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UkwWypozyczalnia.Models;
using UkwWypozyczalnia.ViewModels;

namespace UkwWypozyczalnia.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<User> _userManager { get; }
		private SignInManager<User> _signInManager { get; }


		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel user)
		{
			if (ModelState.IsValid)
			{
				var newUser = new User()
				{ FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Password = user.Password, UserName = user.Email };

				var result = await _userManager.CreateAsync(newUser, newUser.Password);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(newUser, false);

					return RedirectToAction("Index", "Home");
				}
				else
				{
					var errorList = result.Errors.ToList();
					ViewBag.result = string.Join("\n", errorList.Select(e => e.Description));
				}
			}
			return View(user);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel user)
		{
			if (!ModelState.IsValid)
			{
				return View(user);
			}

			var result = await _signInManager.PasswordSignInAsync(user.Login, user.Password, false, false);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("", "Logowanie nie powiodło się.");
			}

			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
