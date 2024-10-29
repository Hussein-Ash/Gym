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
        public DateTime BirthDay { get; set; }
        public int? Role { get; set; }
        public string? Img { get; set; }

        // public string? Password { get; set; }
    }
}