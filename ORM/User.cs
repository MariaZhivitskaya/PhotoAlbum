using System;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public bool Banned { get; set; }
    }
}
