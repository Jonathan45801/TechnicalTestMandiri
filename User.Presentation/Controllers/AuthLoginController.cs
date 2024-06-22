using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Application.UseCases.Login;

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
    }
}
