using Microsoft.AspNetCore.Mvc;
using System;
using ShoppingOL.Data;
using ShoppingOL.Data.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace ShoppingOL.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IShoppingRepository repository;
        private readonly ILogger<OrdersController> logger;       
        private readonly UserManager<StoreUser> _userManager;

        public OrdersController(IShoppingRepository repository, ILogger<OrdersController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {

                logger.LogError("Failed to get orders: {0}", ex);
                return BadRequest("Failed to get orders.");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = repository.GetOrderById(id);
                if (order != null) return Ok(order);
                else return NotFound();
                
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to get orders: {0}", ex);
                return BadRequest("Failed to get orders.");
            }
        }       

    }
}

