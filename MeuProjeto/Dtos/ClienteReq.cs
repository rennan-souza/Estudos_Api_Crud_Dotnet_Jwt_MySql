using MeuProjeto.Validations;
using System.ComponentModel.DataAnnotations;

namespace MeuProjeto.Dtos
{
    public class ClienteReq
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Cpf(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }
    }
}
