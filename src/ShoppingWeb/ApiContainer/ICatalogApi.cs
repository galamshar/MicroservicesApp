using ShoppingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWeb.ApiContainer
{
    public interface ICatalogApi
    {
        Task<IEnumerable<ProductResponse>> GetProducts();
        Task<ProductResponse> GetProduct(string id);
        Task<IEnumerable<ProductResponse>> GetProductsByCategory(string category);

    }
}
