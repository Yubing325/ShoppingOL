using System.Collections.Generic;
using ShoppingOL.Data.Entities;

namespace ShoppingOL.Data
{
    public interface IShoppingRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        bool SaveAll();
    }
}