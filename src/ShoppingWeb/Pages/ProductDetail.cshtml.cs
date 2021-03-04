using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWeb.ApiContainer;
using ShoppingWeb.Models;

namespace AspnetRunBasics
{
    public class ProductDetailModel : PageModel
    {
        private ICatalogApi _catalogApi;
        private IBasketApi _basketApi;

        public ProductDetailModel(ICatalogApi catalogApi, IBasketApi basketApi)
        {
            _catalogApi = catalogApi;
            _basketApi = basketApi;
        }

        public ProductResponse Product { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            Product = await _catalogApi.GetProduct(productId.Value.ToString());
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });

            //await _cartRepository.AddItem("test", productId, Quantity, Color);
            return RedirectToPage("Cart");
        }
    }
}