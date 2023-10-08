using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ProcessJudicial.Domain.Entities
{
    public class Documents
    {
        [Key]
        [Required]
        public long IdDocument { get; set; }
        [Required]
        public long IdUsers { get; set; }
        [Required]
        public long IdJudicialProcess { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public string Extension { get; set; }
        [ForeignKey("IdUsers")]
        public virtual Users user { get; set; }
        [ForeignKey("IdJudicialProcess")]
        public virtual JudicialProcess JudicialProcess { get; set; }

    }
}
