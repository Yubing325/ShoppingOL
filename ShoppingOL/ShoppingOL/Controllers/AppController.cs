using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOL.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            //throw new InvalidOperationException("sdfs");
            return View();
        }
        [HttpGet("About")]
        public IActionResult About()
        {
            return View();
        }
        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
