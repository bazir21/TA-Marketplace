using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string TCDEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}