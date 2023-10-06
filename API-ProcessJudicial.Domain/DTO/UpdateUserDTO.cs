using System.ComponentModel.DataAnnotations;

namespace API_ProcessJudicial.Domain.DTO
{
    public class UpdateUserDTO
    {
        [Required]
        public long IdUsers { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public bool IsAdvogado { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
