using System.ComponentModel.DataAnnotations;

namespace API_ProcessJudicial.Domain.DTO
{
    public class ProcessJudicialDTO
    {
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
    }
}
