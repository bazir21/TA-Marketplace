using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marketplace.Models;
using Marketplace.Data;
using Marketplace.Services;
using System;


namespace Marketplace.Controllers
{
    [Authorize(Policy = "RequireInstructorRole")]
    public class InstructorController : Controller
    {  
        public InstructorService InstructorService;

        public InstructorController(InstructorService InstructorService)
        {
            this.InstructorService = InstructorService;
        }
        
        public IActionResult Index()
        {
            ViewBag.AcceptedBids = InstructorService.GetAcceptedBids("Conn Breathnach");
            ViewBag.RejectedBids = InstructorService.GetRejectedBids("Conn Breathnach");
            ViewBag.PendingBids = InstructorService.GetPendingBids("Conn Breathnach");
            return View();
        }

    }
}