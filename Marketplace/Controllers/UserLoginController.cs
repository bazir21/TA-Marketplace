using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using Marketplace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Marketplace.Data;
using Marketplace.Services;

namespace Marketplace.Controllers
{
    public class UserLoginController : Controller
    {
//
// GET: /UserLogin/

    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ActionResult UserLogin()
    {
        return View();
    }

    //This the Login method. It passes a object of my Model Class named "User".
    [HttpPost]
    public ActionResult UserLogin(User users)
    {
    if (ModelState.IsValid)
    {
        //message will collect the String value from the model method.
        String message = users.LoginProcess(users.UserId, users.Password);
        //RedirectToAction("actionName/ViewName_ActionResultMethodName", "ControllerName");
    if (message.Equals("1"))
    {
        //this will add cookies for the username.
        //Response.Cookies.Add(new HttpCookie("Users1", users.UserName));
        //This is a different Controller for the User Homepage. Redirecting after successful process.
        return RedirectToAction("Home", "UserHome");
    }
    else
        ViewBag.ErrorMessage = message;
    }
    return View(users);
        }

    }
}