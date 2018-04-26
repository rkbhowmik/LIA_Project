﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LIA.UI.Models;
using Microsoft.AspNetCore.Identity;
using LIA.Data.Data.Entities;

namespace LIA.UI.Controllers
{
    public class HomeController : Controller
    {
        //To get logged in user information
        #region
        public SignInManager<User> _signInManager;
        public HomeController(SignInManager<User> signInManager) => _signInManager = signInManager;
        #endregion
        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Login", "Account", null);
            }
            else
            {
                return RedirectToAction("Dashboard", "MemberShip", null);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
