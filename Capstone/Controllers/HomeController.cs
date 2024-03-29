﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //if this user.role = said role send them to the create page of said user role
            //find current user, find current users role (.notation), current user role to create page of roles controller
            ViewBag.Title = "Home Page";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//redirecting them from home controller to the get 