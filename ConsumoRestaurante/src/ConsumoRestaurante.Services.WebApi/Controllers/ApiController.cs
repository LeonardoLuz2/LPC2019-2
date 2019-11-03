using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ConsumoRestaurante.Services.WebApi.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected IActionResult ResponseOk(object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        protected IActionResult ResponseModelStateError()
        {
            var errors = ModelState.Values.SelectMany(p => p.Errors);

            return BadRequest(new
            {
                success = false,
                errors = errors.Select(p => p.ErrorMessage)
            });
        }

        protected IActionResult ResponseError(object error)
        {
            return BadRequest(new
            {
                success = false,
                errors = error
            });
        }
    }
}
