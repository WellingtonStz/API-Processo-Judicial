using System.ComponentModel.DataAnnotations;

namespace API_ProcessJudicial.Domain.Entities
{
    public class Users
    {
        [Key]
        [Required]
        public long IdUsers { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public bool IsAdvogado { get; set; }
        public string Password { get; set; }


    }
}
