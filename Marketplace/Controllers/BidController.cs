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
            return View();
        }
        [HttpPost]
        public IActionResult Create(BidModel bid)
        {
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
