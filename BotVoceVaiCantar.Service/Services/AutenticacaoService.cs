using BotVoceVaiCantar.Domain.Contracts;
using BotVoceVaiCantar.Domain.Interfaces;
using BotVoceVaiCantar.Domain.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BotVoceVaiCantar.Service.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private string _tokenJwt;
        //private async Task MontaToken(Usuario entity)
        //{
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()),
        //            new Claim(ClaimTypes.Name, entity.Nome),
        //            new Claim(ClaimTypes.Email, entity.Email),
        //            new Claim(ClaimTypes.Role, entity.Role.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials = new SigningCredentials(
        //            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.JwtSecurityKey)),
        //            SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    _tokenJwt = tokenHandler.WriteToken(token);
        //    _expiracao = tokenDescriptor.Expires;
        //}

        //private async Task<Usuario> BuscaUsuarioOrFail(string email)
        //{
        //    var usuario = await _usuarioRepository.FindAsync(x => x.Email.Equals(email) && x.Ativo);

        //    if (usuario is null)
        //    {
        //        throw new Exception("Usuário não encontrado!");
        //    }

        //    return usuario;
        //}

        public Task<AutenticacaoResponse> AutenticarAsync(AutenticacaoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
