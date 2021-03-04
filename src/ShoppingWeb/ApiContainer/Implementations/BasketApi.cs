using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingWeb.ApiContainer.Infrastructure;
using ShoppingWeb.Models;
using ShoppingWeb.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShoppingWeb.ApiContainer.Implementations
{
    public class BasketApi : BaseHttpClientWithFactory, IBasketApi
    {
        private readonly IApiSettings _settings;

        public BasketApi(IHttpClientFactory factory, IApiSettings settings) : base(factory)
        {
            _settings = settings;
        }

        public async Task<IActionResult> Checkout(BasketCheckoutResponse basketCheckout)
        {
            var basketContent = new StringContent(JsonConvert.SerializeObject(basketCheckout), System.Text.Encoding.UTF8, "application/json");
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath($"{_settings.BasketPath}/Checkout")
                .Content(basketContent)
                .HttpMethod(HttpMethod.Post)
                .GetHttpMessage();
            return await base.SendRequest<IActionResult>(message);
        }

        public async Task<IActionResult> DeleteBasket(string username)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.BasketPath)
                .AddQueryString("username", username)
                .HttpMethod(HttpMethod.Delete)
                .GetHttpMessage();
            return await base.SendRequest<IActionResult>(message);
        }

        public async Task<BasketCartResponse> GetBasket(string username)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                         .SetPath(_settings.BasketPath)
                         .AddQueryString("username", username)
                         .HttpMethod(HttpMethod.Get)
                         .GetHttpMessage();
            return await base.SendRequest<BasketCartResponse>(message);
        }

        public async Task<BasketCartResponse> UpdateBasket(BasketCartResponse basketCart)
        {
            var basketContent = new StringContent(JsonConvert.SerializeObject(basketCart), System.Text.Encoding.UTF8, "application/json");
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.BasketPath)
                .Content(basketContent)
                .HttpMethod(HttpMethod.Post)
                .GetHttpMessage();
            return await base.SendRequest<BasketCartResponse>(message);
        }
    }
}
