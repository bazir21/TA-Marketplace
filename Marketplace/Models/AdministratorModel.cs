using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Marketplace.Models
{
    public class AdministratorModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string TCDEmail { get; set; }
        public ICollection<ModuleModel> Modules { get; set; }
        //TODO: Permissions
    }
}