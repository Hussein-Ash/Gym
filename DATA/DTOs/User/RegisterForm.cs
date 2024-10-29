using System.ComponentModel.DataAnnotations;
using EvaluationBackend.Entities;

namespace EvaluationBackend.DATA.DTOs.User
{
    public class RegisterForm
    {
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string? Password { get; set; }
        [Required]
        public string? UserName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "FullName must be at least 2 characters")]
        public string? FullName { get; set; }
        
        [Required]
        public string? Img { get; set; }

    }
}