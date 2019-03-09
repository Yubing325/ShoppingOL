using Microsoft.AspNetCore.Mvc;
using ShoppingOL.Data;
using ShoppingOL.Services;
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
        private readonly IShoppingRepository repository;
        private readonly IMailService mailService;

        public AppController(IShoppingRepository repository, IMailService mailService)
        {
            this.repository = repository;
            this.mailService = mailService;
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
                mailService.SendMessage("s@xxx.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent!";
                ModelState.Clear();
            }
            else
            {

            }


            return View();
        }

        public IActionResult Shop() {
            var result = repository.GetAllProducts();
            return View(result);
        }
    }
}
