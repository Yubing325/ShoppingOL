using Microsoft.AspNetCore.Mvc;
using System;
using ShoppingOL.Data;
using ShoppingOL.Data.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using ShoppingOL.ViewModels;

namespace ShoppingOL.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IShoppingRepository repository;
        private readonly ILogger<OrdersController> logger;
        private readonly IMapper mapper;
        

        public OrdersController(IShoppingRepository repository, ILogger<OrdersController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
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
                if (order != null) return Ok(mapper.Map<Order,OrderViewModel>(order));
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

