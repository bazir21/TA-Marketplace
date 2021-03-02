using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Marketplace.Models
{
    public class Administrator
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        //TODO: Permissions
        public ICollection<Module> Modules { get; set; }
    }
}