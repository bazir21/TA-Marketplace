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
    public class BidController : Controller
    {  
        public BidService BidService;
        public IEnumerable<BidModel> Bids { get; private set; }

        public BidController(BidService bid)
        {
            BidService = bid;
        }
        
        public IActionResult Index()
        {
            Bids = BidService.GetBids();
            return View(Bids);
        }

        public IActionResult Create(int moduleId)
        {
            TempData["module"] = moduleId;
            Console.WriteLine(moduleId);
            return View();
        }
        [HttpPost]
        public IActionResult Create(BidModel bid)
        {
            // Console.WriteLine(bid.Id);
            // Console.WriteLine(bid.ModuleBiddedId);
            // Console.WriteLine(bid.InstructorBidded);
            // Console.WriteLine(bid.HoursBid);
            // Console.WriteLine(bid.Accepted);
            int moduleId;
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
            
            
            BidService.CreateBid(bid);
            
            
            
            return RedirectToAction(nameof(Index));
        }


    }
}