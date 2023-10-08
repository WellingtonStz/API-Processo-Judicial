using System.ComponentModel.DataAnnotations;

namespace API_ProcessJudicial.Domain.DTO
{
    public class LoginDTO
    {
        [Required]
        public string CPF { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
