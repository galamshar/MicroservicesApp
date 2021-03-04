using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingWeb.ApiContainer;
using ShoppingWeb.Models;

namespace AspnetRunBasics
{
    public class CartModel : PageModel
    {
        private readonly IBasketApi _basketApi;

        public CartModel(IBasketApi basketApi)
        {
            _basketApi = basketApi;
        }

        public BasketCartResponse Cart { get; set; } = new BasketCartResponse();        

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _basketApi.GetBasket("test");           

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        {
            await _basketApi.DeleteBasket("test");
            return RedirectToPage();
        }
    }
}