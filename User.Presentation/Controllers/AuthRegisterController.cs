using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Application.UseCases.Command.Register;

namespace User.Presentation.Controllers
{
    [Route("/Auth/Register")]
    [ApiController]
    public class AuthRegisterController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterCommand register)
        {
            return Ok(await Mediator.Send(register));
        }
    }
}
