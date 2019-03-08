using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public void AddEntity(object model)
        {
             ctx.Add(model);
        }

        public void AddOrder(Order newOrder)
        {
            foreach (var item in newOrder.Items)
            {
                item.Product = ctx.Products.Find(item.Product.Id);
            }

            AddEntity(newOrder);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return ctx.Orders
                .Include(o=>o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {

                return ctx.Orders
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Product)
                           .ToList();

            }
            else
            {
                return ctx.Orders
                           .ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {

                return ctx.Orders
                           .Where(o => o.User.UserName == username)
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Product)
                           .ToList();

            }
            else
            {
                return ctx.Orders
                           .Where(o => o.User.UserName == username)
                           .ToList();
            }
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

        public Order GetOrderById(int id)
        {
            return ctx.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .Where(o => o.Id == id)
                    .FirstOrDefault();

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

        public Order GetOrderById(string username, int id)
        {
            return ctx.Orders
                       .Include(o => o.Items)
                       .ThenInclude(i => i.Product)
                       .Where(o => o.Id == id && o.User.UserName == username)
                       .FirstOrDefault();
        }
    }
}
