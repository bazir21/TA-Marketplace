using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity; 
namespace Marketplace.Models
{
    public class UserModel : IdentityUser
    {
        public string Name { get; set; }
    }
}