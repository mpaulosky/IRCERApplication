using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace IRCERPortal.Authentication
{
		public class JwtParser
		{
				/// <summary>
				/// Parse Claims From Jwt
				/// </summary>
				/// <param name="jwt"></param>
				/// <returns>IEnumerable list of Claims</returns>
				public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
				{
						var claims = new List<Claim>();
						var payload = jwt.Split('.')[1];

						var jsonBytes = ParseBase64WithoutPadding(payload);

						var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

						ExtractRolesFromJwt(claims, keyValuePairs);

						claims.AddRange(keyValuePairs
								.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

						return claims;
				}

				/// <summary>
				/// Extract Roles From Jwt
				/// </summary>
				/// <param name="claims"></param>
				/// <param name="keyValuePairs"></param>
				private static void ExtractRolesFromJwt(List<Claim> claims, Dictionary<string, object> keyValuePairs)
				{
						keyValuePairs.TryGetValue(ClaimTypes.Role, out var roles);

						if (roles is not null)
						{
								var parseRoles = roles.ToString()?.Trim().TrimStart('[').TrimEnd(']').Split(',');

								if (parseRoles.Length > 1)
								{
										foreach (var parsedRole in parseRoles)
										{
												claims.Add(new Claim(ClaimTypes.Role, parsedRole.Trim('"')));
										}
								}
								else
								{
										claims.Add(new Claim(ClaimTypes.Role, parseRoles[0]));
								}

								keyValuePairs.Remove(ClaimTypes.Role);
						}


				}

				/// <summary>
				/// Parse Base64 Without Padding
				/// </summary>
				/// <param name="base64"></param>
				/// <returns>byte[]</returns>
				private static byte[] ParseBase64WithoutPadding(string base64)
				{
						switch (base64.Length % 4)
						{
								case 2:
										base64 += "==";
										break;
								case 3:
										base64 += "=";
										break;
						}

						return Convert.FromBase64String(base64);
				}
		}
}
