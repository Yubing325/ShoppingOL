﻿using Microsoft.Extensions.Logging;
using ShoppingOL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOL.Data
{
    public class ShoppingRepository : IShoppingRepository
    {
        private readonly CustomDBContext ctx;
        private readonly ILogger<ShoppingRepository> logger;

        public ShoppingRepository(CustomDBContext ctx,ILogger<ShoppingRepository> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                logger.LogInformation("GetAllProducts was Called");

                return ctx.Products.OrderBy(p => p.Title)
                    .ToList();
            }
            catch (Exception ex)
            {

                logger.LogError("Failed to get all products: {0}", ex);
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public bool SaveAll()
        {
            return ctx.SaveChanges() > 0;
        }
    }
}