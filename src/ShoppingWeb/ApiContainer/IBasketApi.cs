using Microsoft.AspNetCore.Mvc;
using ShoppingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWeb.ApiContainer
{
    public interface IBasketApi
    {
        Task<BasketCartResponse> GetBasket(string username);
        Task<BasketCartResponse> UpdateBasket(BasketCartResponse basketCart);
        Task<IActionResult> DeleteBasket(string username);
        Task<IActionResult> Checkout(BasketCheckoutResponse basketCheckout);
    }
}
