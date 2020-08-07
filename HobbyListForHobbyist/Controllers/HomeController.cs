using HobbyListForHobbyist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Class constructor. Needs an ILogger<T> param.
        /// </summary>
        /// <param name="logger">ILogger<T> Interface</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Render the index in the View directory
        /// </summary>
        /// <returns>IActionResult</returns>
        [AllowAnonymous]
        public IActionResult Index()
        {            
            return View();
        }

        /// <summary>
        /// Render the privacy in the view directory
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// If there is an error use this route.
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
