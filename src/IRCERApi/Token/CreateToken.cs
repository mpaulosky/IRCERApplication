using IRCERApi.Library.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IRCERApi.Token
{
	public class CreateToken : ICreateToken
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IConfiguration _config;

		public CreateToken(ApplicationDbContext context,
											 UserManager<IdentityUser> userManager,
											 IConfiguration config)
		{
			_context = context;
			_userManager = userManager;
			_config = config;
		}

		public async Task<dynamic> GenerateToken(string username)
		{
			var user = await _userManager.FindByNameAsync(username);

			var roles = from ur in _context.UserRoles
									join r in _context.Roles on ur.RoleId equals r.Id
									where ur.UserId == user.Id
									select new { ur.UserId, ur.RoleId, r.Name };

			var claims = new List<Claim>
						{
								new Claim(ClaimTypes.Name, username),
								new Claim(ClaimTypes.NameIdentifier, user.Id),
								new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
								new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
						};

			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role.Name));
			}

			var key = _config.GetValue<string>("Secrets:SecurityKey");

			var token = new JwtSecurityToken(
					new JwtHeader(
							new SigningCredentials(
									new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
									SecurityAlgorithms.HmacSha256)),
					new JwtPayload(claims));

			var output = new
			{
				Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
				UserName = username
			};

			return output;
		}
	}
}
