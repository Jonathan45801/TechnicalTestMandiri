using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Application.UseCases.Command.Login;
using User.Application.UseCases.Queries.Token;
namespace User.Presentation.Controllers
{
    [Route("/Auth/Login")]
    [ApiController]
    public class AuthLoginController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginUser([FromBody] LoginCommand login)
        {
            return Ok(await Mediator.Send(login));
        }
        [HttpGet]
        [Route("/Auth/token/{Token}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchToken(string Token)
        {
            var data = new TokenQueries(Token);
            return Ok(await Mediator.Send(data));
        }
    }
}
