using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize]
    public class InstructorController : Controller
    {  
        public InstructorService InstructorService;
        private readonly UserManager<InstructorModel> _userManager;

        public InstructorController(InstructorService InstructorService, UserManager<InstructorModel> userManager)
        {
            this.InstructorService = InstructorService;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            //List bids created by user
            var user = await _userManager.GetUserAsync(User);
            Console.WriteLine("User Id is : " + user.Id);
            ViewBag.AcceptedBids = InstructorService.GetAcceptedBids(user.Id);
            ViewBag.RejectedBids = InstructorService.GetRejectedBids(user.Id);
            ViewBag.PendingBids = InstructorService.GetPendingBids(user.Id);
            return View();
        }

    }
}