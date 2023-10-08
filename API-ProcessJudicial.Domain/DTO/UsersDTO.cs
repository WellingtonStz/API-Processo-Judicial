﻿using System.ComponentModel.DataAnnotations;

namespace API_ProcessJudicial.Domain.DTO
{
    public class UsersDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public bool IsAdvogado { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Oab { get; set; }


    }
}
