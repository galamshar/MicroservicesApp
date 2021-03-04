using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWeb.ApiContainer;
using ShoppingWeb.Models;

namespace AspnetRunBasics.Pages
{
    public class IndexModel : PageModel
    {
        private ICatalogApi _catalogApi;
        private IBasketApi _basketApi;

        public IndexModel(ICatalogApi catalogApi, IBasketApi basketApi)
        {
            _catalogApi = catalogApi;
            _basketApi = basketApi;
        }

        public IEnumerable<ProductResponse> ProductList { get; set; } = new List<ProductResponse>();

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _catalogApi.GetProducts();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });

            //await _cartRepository.AddItem("test", productId);
            return RedirectToPage("Cart");
        }
    }
}
