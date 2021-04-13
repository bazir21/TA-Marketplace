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
    public class AdminController : Controller
    {  
        public AdminService AdminService;

        public AdminController(AdminService AdminService)
        {
            this.AdminService = AdminService;
        }
        
        public IActionResult Index()
        {
            ViewBag.ActiveBids= AdminService.GetModulesWithBids();
            ViewBag.ViewInstructors= AdminService.ViewInstructors();
            ViewBag.AmountOfBids= AdminService.GetAmountOfBids();
            ViewBag.ViewModules= AdminService.ViewModules();
            return View();
        }

        public IActionResult EditInstructor(int InstructorId)
        {
            InstructorModel instructorToEdit= AdminService.GetInstructorById(InstructorId);
            return View(instructorToEdit);
        }

        [HttpPost]
        public IActionResult EditInstructor(InstructorModel InstructorToEdit)
        {
            AdminService.EditInstructor(InstructorToEdit);
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult EditModule(int ModuleId)
        {
            ModuleModel moduleToEdit= AdminService.GetModuleById(ModuleId);
            return View(moduleToEdit);
        }

        [HttpPost]
        public IActionResult EditModule(ModuleModel ModuleToEdit)
        {
            AdminService.EditModule(ModuleToEdit);
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult ViewBidders(int ModuleId)
        {
            ViewBag.ViewBidders= AdminService.GetInstructorsThatBid(ModuleId);
            return View();
        }
    }
}