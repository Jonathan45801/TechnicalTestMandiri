using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.UseCases.Command.ProductCreate;
using Product.Application.UseCases.Command.ProductUpdate;
using Product.Application.UseCases.Command.ProductDelete;
namespace Product.Presentation.Controllers
{
    [Route("/Product")]
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProductAdd([FromBody] ProductCreateCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProductUpdate([FromBody] ProductUpdateCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProductDelete([FromBody] ProductDeleteCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
