using IRCERApiDataManager.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IRCERApi.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			//string[] roles = { "Admin", "Manager", "Cashier" };

			//foreach (var role in roles)
			//{
			//    var roleExist = await _roleManager.RoleExistsAsync(role);

			//    if (roleExist == false)
			//    {
			//        await _roleManager.CreateAsync(new IdentityRole(role));
			//    }
			//}

			//var user = await _userManager.FindByEmailAsync("tim@iamtimcorey.com");

			//if (user != null)
			//{
			//    await _userManager.AddToRoleAsync(user, "Admin");
			//    await _userManager.AddToRoleAsync(user, "Cashier");
			//}

			return View();
		}

		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		//public IActionResult Error()
		//{
		//    var err = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier };
		//    return View(err);
		//}
	}
}
