using System.Collections.Generic;
using System.Linq;
using ShoppingOL.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingOL.Data;

namespace ShoppingOL.Controllers
{
    [Route("/api/orders/{orderid}/items")]
  [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
  public class OrderItemsController : Controller
  {
    private readonly IShoppingRepository _repository;
    private readonly ILogger<OrderItemsController> _logger;
   

    public OrderItemsController(IShoppingRepository repository, 
      ILogger<OrderItemsController> logger )
    {
      _repository = repository;
      _logger = logger;
      
    }

    [HttpGet]
    public IActionResult Get(int orderId)
    {
      var order = _repository.GetOrderById(User.Identity.Name, orderId);
      if (order != null) return Ok();
      return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int orderId, int id)
    {
      var order = _repository.GetOrderById(User.Identity.Name, orderId);
      if (order != null)
      {
        var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
        if (item != null)
        {
          return Ok((item));
        }
      }
      return NotFound();

    }


  }
}
