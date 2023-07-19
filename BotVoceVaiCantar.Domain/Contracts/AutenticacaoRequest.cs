using System.ComponentModel.DataAnnotations;

namespace BotVoceVaiCantar.Domain.Contracts
{
    public class AutenticacaoRequest
    {
        [Required(ErrorMessage = "O campo 'Email' é obrigatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo 'Senha' é obrigatorio")]
        public string Senha { get; set; }
    }
}
