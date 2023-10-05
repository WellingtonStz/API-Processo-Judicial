using System.ComponentModel.DataAnnotations;

namespace API_ProcessJudicial.Domain.DTO
{
    public class UsersDTO
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo 'CPF' é obrigatório.")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O campo 'Advogado' é obrigatório.")]
        public bool IsAdvogado { get; set; }
        [Required(ErrorMessage = "O campo 'Senha' é obrigatório.")]
        public string Password { get; set; }


    }
}
