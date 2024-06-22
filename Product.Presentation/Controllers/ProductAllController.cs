using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.UseCases.Queries.Product;
namespace Product.Presentation.Controllers
{
    [Route("/Catalog")]
    [ApiController]
    public class ProductAllController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProductAll([FromQuery] ProductAllQueries request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
