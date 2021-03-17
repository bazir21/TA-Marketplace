using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Marketplace.Services;
using Marketplace.Models;
using System.Net;

namespace Marketplace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public JsonFileInstructor InstructorService;

        public JsonFileModuleService ModuleService;
        public IEnumerable<InstructorModel> Instructors { get; private set; }

        public IEnumerable<ModuleModel> Modules { get; private set; }

        public HomeController(ILogger<HomeController> logger, JsonFileInstructor instructor, JsonFileModuleService module)
        {
            _logger = logger;
            InstructorService = instructor;
            ModuleService = module;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Administrator()
        {
            Instructors = InstructorService.GetInstructors();
            return View(Instructors);
        }

        public IActionResult Instructor()
        {
            Modules = ModuleService.GetModules();
            return View(Modules);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
