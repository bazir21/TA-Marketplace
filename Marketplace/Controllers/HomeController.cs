using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Marketplace.Models;
using System.Net;
using Newtonsoft.Json;

namespace Marketplace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            var webClient= new WebClient();
            var instructorsJson= webClient.DownloadString("C:/My Folder/University/Software Engineering Project/TA-Marketplace/Marketplace/wwwroot/data/instructors.json");
            var InstructorList= JsonConvert.DeserializeObject<InstructorsModel>(instructorsJson);
            return View(InstructorList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
