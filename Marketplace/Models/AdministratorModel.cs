using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity; 

namespace Marketplace.Models
{
    public class AdministratorModel : UserModel
    {
        public ICollection<ModuleModel> Modules { get; set; }
        //TODO: Permissions
    }
}