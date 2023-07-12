using System.ComponentModel.DataAnnotations;

namespace BotVoceVaiCantar.Domain.Contracts
{
    public class AutenticacaoRequest
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo 'Senha' é obrigatorio")]
        public string Senha { get; set; }
    }
}
