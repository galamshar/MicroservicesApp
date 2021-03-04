using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWeb.ApiContainer;
using ShoppingWeb.Models;

namespace AspnetRunBasics
{
    public class CheckOutModel : PageModel
    {
        private readonly IBasketApi _basketApi;
        private readonly IOrderApi _orderApi;

        public CheckOutModel(IBasketApi basketApi, IOrderApi orderApi)
        {
            _basketApi = basketApi;
            _orderApi = orderApi;
        }

        [BindProperty]
        public BasketCheckoutResponse Order { get; set; }

        public BasketCartResponse Cart { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var response = await _basketApi.Checkout(Order);
            return Page();
        }
    }
}