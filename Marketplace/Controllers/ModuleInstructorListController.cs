using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marketplace.Models;
using Marketplace.Data;
using Marketplace.Services;


namespace Marketplace.Controllers
{
    public class InstructorModuleController : Controller
    {  
        public ModuleInstructorListService ModuleService;
        public IEnumerable<ModuleModel> Modules { get; private set; }

        public InstructorModuleController(ModuleInstructorListService module)
        {
            ModuleService = module;
        }
        
        public IActionResult Index()
        {
            Modules = ModuleService.GetModules();
            return View(Modules);
        }

        public IActionResult Details(ModuleModel module)
        {
            return View(module);
        }
        public IActionResult Create(ModuleModel module)
        {
            return RedirectToAction("Create", "Bid", new { moduleId = module.Id });
        }
        

    }
}