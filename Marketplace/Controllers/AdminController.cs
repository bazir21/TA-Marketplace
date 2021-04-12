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

        public AdminController(AdminService admin)
        {
            AdminService = admin;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}