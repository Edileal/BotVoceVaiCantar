using BotVoceVaiCantar.Domain.Contracts;
using BotVoceVaiCantar.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BotVoceVaiCantar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CantorController : ControllerBase
    {
        private readonly ICantorService _cantorService;

        public CantorController(ICantorService cantorService)
        {
            _cantorService = cantorService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CantorResponse>> GetById(Guid id)
        {
            try
            {
                var result = await _cantorService.ObterPorIdAsync(id);
                return Ok(result);
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CantorResponse>>> Get()
        {
            try
            {
                var result = await _cantorService.ObterTodosAsync();
                return Ok(result);
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CantorResponse>> Post([FromBody] CantorRequest usuario)
        {
            try
            {
                var result = await _cantorService.CriarAsync(usuario);
                return Created(nameof(Post), result);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException); }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CantorResponse>> Put([FromBody] CantorRequest request, [FromRoute] Guid id)
        {
            try
            {
                var result = await _cantorService.AtualizarAsync(id, request);
                return Ok(result);
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _cantorService.DeletarAsync(id);
                return NoContent();
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CantorResponse>> PatchData(DateTime dataNova, Guid id)
        {

            try
            {
                var result = await _cantorService.AdicionarEOuAlterarData(dataNova, id);
                return Ok(result);
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
