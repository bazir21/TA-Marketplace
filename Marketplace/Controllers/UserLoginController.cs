using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Marketplace.Models;
using Marketplace.Data;
using Marketplace.Services;
using System;
using System.Linq;
using System.Web;

namespace Marketplace.Controllers
{
    public class UserLoginController : Controller
    {
        LoginService LoginService;

        public UserLoginController(LoginService login)
        {
            LoginService= login;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(UserModel user)
        {
            if (LoginService.LoginProcess(user.Email, user.Password))
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Index", "UserLogin");    
        }
    }
}