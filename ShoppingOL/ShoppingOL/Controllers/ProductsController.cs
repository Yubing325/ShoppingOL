using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingOL.Data;
using ShoppingOL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOL.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController: Controller
    {
        private readonly IShoppingRepository shoppingRepo;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IShoppingRepository shoppingRepo, ILogger<ProductsController> logger)
        {
            this.shoppingRepo = shoppingRepo;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Return 200
                return Ok(shoppingRepo.GetAllProducts());

            }
            catch (Exception ex)
            {
                logger.LogError("Failed to get products,{0}", ex);
                return BadRequest("Sorry! Server failed to get products, please try again later.");
            }
        }
    }
}
