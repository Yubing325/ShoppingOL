using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOL.Controllers
{
    public class ProductsController: Controller
    {
        private readonly IShoppingRepository shoppingRepo;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IShoppingRepository shoppingRepo, ILogger<ProductsController> logger)
        {
            this.shoppingRepo = shoppingRepo;
            this.logger = logger;
        }


    }
}
