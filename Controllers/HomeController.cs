using System.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Registermvc.Models;
using Registermvc.Services;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Registermvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegister _register;

        public HomeController(ILogger<HomeController> logger, IRegister register)
        {
            _logger = logger;
            _register = register;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy(Register model)
        {
            return View(model);
        }


                // Register registerview  = (Register)TempData["data"];
                // return View(registerview);
            
            //  var data = TempData["data"];
            // var userprofile = JsonConvert.DeserializeObject<Register>(data);
            // return View(userprofile);
        

        [HttpPost]

        public IActionResult Index(RegisterViewModel model)
        {
            if (!ModelState.IsValid) { return View(); }

            var result = _register.RegisterNewUser(model);
            if (result.Item2 == 1)
            {

                return RedirectToAction("Privacy","Home", result.Item1);
            }
            else
            {
                return View();
            }

        }






        // public IActionResult Index(RegisterViewModel model)
        // {
        //     if (!ModelState.IsValid) { return View(); }

        //     string result = _register.RegisterNewUser(model);
        //     if (result.Item2 == 1)
        //     {
                     
               
        //         var data = JsonConvert.SerializeObject(result.Item1);
        //         // HttpContext.Session.SetString("data", data);
        //          TempData["data"]= data;


        //         return LocalRedirect("~/Home/Privacy");
        //     }
        //     else
        //     {
        //         return View();
        //     }



        
    }
}
