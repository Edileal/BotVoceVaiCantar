using BotVoceVaiCantar.Domain.Contracts;
using BotVoceVaiCantar.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace BotVoceVaiCantar.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAutenticacaoService _authService;
        public AuthController(IAutenticacaoService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(200)]
        //[SwaggerOperation(Summary = "Loga usuario e retorna jwt")]
        public async Task<ActionResult<AutenticacaoResponse>> LogaUsuario([FromBody] AutenticacaoRequest loginRequest)
        {
            var jwt = await _authService.AutenticarAsync(loginRequest);
            return Ok(jwt);
        }

    }

}
