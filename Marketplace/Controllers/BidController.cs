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
    public class BidController : Controller
    {  
        public BidService BidService;
        public IEnumerable<BidModel> Bids { get; private set; }

        private readonly UserManager<InstructorModel> _userManager;

        public BidController(BidService bid, UserManager<InstructorModel> userManager)
        {
            BidService = bid;
            _userManager = userManager;
        }
        
        public IActionResult Index()
        {
            Bids = BidService.GetBids();
            return View(Bids);
        }

        public IActionResult Create(int moduleId)
        {
            TempData["module"] = moduleId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BidModel bid)
        {
            int moduleId;
            var user = await _userManager.GetUserAsync(User);
            if(TempData["module"] != null)
            {
                moduleId = (int)TempData["module"];
                TempData["module"] = null;
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

            bid.ModuleModelId = moduleId;  
            bid.InstructorBiddedId = user.Id;
            bid.InstructorBidded = user.Name;
            BidService.CreateBid(bid);
            
            
            
            return RedirectToAction("Index", "Instructor");
        }

        public IActionResult Edit(int bidId)
        {
            BidModel bidToEdit = BidService.getBidById(bidId);
            return View(bidToEdit);
        }

        [HttpPost]
        public IActionResult Edit(BidModel editedBid)
        {
            
            BidService.EditBid(editedBid);
            return RedirectToAction("Index", "Instructor");
        }
        public IActionResult Delete(int bidId)
        {
            BidService.DeleteBid(bidId);
            return RedirectToAction("Index", "Instructor");
        }


    }
}
