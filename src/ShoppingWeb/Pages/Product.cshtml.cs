using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWeb.ApiContainer;
using ShoppingWeb.Models;

namespace AspnetRunBasics
{
    public class ProductModel : PageModel
    {
        private ICatalogApi _catalogApi;
        private IBasketApi _basketApi;

        public ProductModel(ICatalogApi catalogApi, IBasketApi basketApi)
        {
            _catalogApi = catalogApi;
            _basketApi = basketApi;
        }

        public IEnumerable<string> CategoryList { get; set; } = new List<string>();
        public IEnumerable<ProductResponse> ProductList { get; set; } = new List<ProductResponse>();


        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(string categoryName)
        {

            if (categoryName.Length > 0)
            {
                ProductList = await _catalogApi.GetProductsByCategory(categoryName);
                SelectedCategory = CategoryList.FirstOrDefault(c => c == categoryName);
            }
            else
            {
                ProductList = await _catalogApi.GetProducts();
            }

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