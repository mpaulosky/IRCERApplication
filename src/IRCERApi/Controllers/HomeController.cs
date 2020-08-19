using Microsoft.AspNetCore.Mvc;

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
	}
}
