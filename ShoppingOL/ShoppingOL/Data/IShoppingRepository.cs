using System.Collections.Generic;
using ShoppingOL.Data.Entities;

namespace ShoppingOL.Data
{
    public interface IShoppingRepository
    {
    IEnumerable<Product> GetAllProducts();
    IEnumerable<Product> GetProductsByCategory(string category);

    IEnumerable<Order> GetAllOrders(bool includeItems);
    IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
    Order GetOrderById(string username, int id);
    void AddOrder(Order newOrder);

    bool SaveAll();
    void AddEntity(object model);
        object GetOrderById(int id);
    }
}