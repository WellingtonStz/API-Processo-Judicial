using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProcessJudicial.Domain.Entities
{
    public class JudicialProcess
    {
        [Key]
        [Required]
        public long IdJudicialProcess { get; set; }
        [Required]
        public long IdUsers { get; set; }
        [Required]
        public string ProcessNumber { get; set; }
        [Required]
        public long Part { get; set; }
        [Required]
        public long Responsible { get; set; }
        [Required]
        public string Documents { get; set; }
        [Required]
        public string Theme { get; set; }
        [Required]
        public double ValueCause { get; set; }

    
        public virtual Users user { get; set; }



    }
}
