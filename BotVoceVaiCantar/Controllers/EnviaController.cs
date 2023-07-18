using BotVoceVaiCantar.Domain.Contracts;
using BotVoceVaiCantar.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BotVoceVaiCantar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnviaController : ControllerBase
    {
        private readonly ICantorService _cantorService;

        public EnviaController(ICantorService cantorService)
        {
            _cantorService = cantorService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] LembreteRequest request)
        {
            try
            {
                await _cantorService.EnviarCantorDiaAsync(request);
                return Created(nameof(Post), new {request});
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException); }
        }
    }
}
