using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWeb.Models
{
    public class BasketCartResponse
    {
        public string Username { get; set; }
        public List<BasketCartItemResponse> Items { get; set; } = new List<BasketCartItemResponse>();

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }

                return totalprice;
            }
        }
    }
}
