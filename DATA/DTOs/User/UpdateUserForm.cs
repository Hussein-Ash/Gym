using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Conventions;
using EvaluationBackend.Entities;

namespace EvaluationBackend.DATA.DTOs.User
{
    public class UpdateUserForm
    {
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
<<<<<<< HEAD
        public string? Password { get; set; }

        public int? Role { get; set; }
        public string? Img { get; set; }
=======
>>>>>>> 6c75216 (Initial commit)

    }
}