using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marketplace.Models;
using Marketplace.Data;
using Marketplace.Services;


namespace Marketplace.Controllers
{
    public class ModuleController : Controller
    {  
        public ModuleInstructorListService ModuleService;
        public IEnumerable<ModuleModel> Modules { get; private set; }

        public ModuleController(ModuleInstructorListService module)
        {
            ModuleService = module;
        }

        public IActionResult Details(int moduleId)
        {
            ModuleModel module = ModuleService.GetModuleById(moduleId);
            return View(module);
        }
        

    }
}