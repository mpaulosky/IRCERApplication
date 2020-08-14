using IRCERApi.Data;
using IRCERApi.Token;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IRCERApi.Controllers
{
    public class TokenController : ControllerBase
    {
        private readonly IValidateUser _validateUser;
        private readonly ICreateToken _createToken;

        public TokenController(IValidateUser validateUser,
                               ICreateToken createToken)
        {
            _validateUser = validateUser;
            _createToken = createToken;
        }

        [Route("/token")]
        [HttpPost]
        public async Task<IActionResult> Create(string username, string password, string grant_type)
        {
            if (await _validateUser.IsValidUsernameAndPassword(username, password))
            {
                return new ObjectResult(await _createToken.GenerateToken(username));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}