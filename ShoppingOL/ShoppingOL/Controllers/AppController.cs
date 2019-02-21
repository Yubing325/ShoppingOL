﻿using Microsoft.AspNetCore.Mvc;
using ShoppingOL.Data;
using ShoppingOL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOL.Controllers
{
    public class AppController : Controller
    {
        private readonly CustomDBContext _context;

        public AppController(CustomDBContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
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
        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {

            }


            return View();
        }

        public IActionResult Shop() {
            var result = _context.Products.ToList();
            return View(result);
        }
    }
}
