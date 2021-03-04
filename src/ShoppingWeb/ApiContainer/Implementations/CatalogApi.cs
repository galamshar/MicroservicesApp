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
    public class CatalogApi : BaseHttpClientWithFactory, ICatalogApi
    {
        private readonly IApiSettings _settings;

        public CatalogApi(IHttpClientFactory factory, IApiSettings settings) : base(factory)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<string>> GetCategories()
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath($"{_settings.CatalogPath}/GetCategories")
                .HttpMethod(HttpMethod.Get)
                .GetHttpMessage();
            return await base.SendRequest<IEnumerable<string>>(message);
        }

        async Task<ProductResponse> ICatalogApi.GetProduct(string id)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.CatalogPath)
                .AddQueryString("id", id)
                .HttpMethod(HttpMethod.Get)
                .GetHttpMessage();
            return await base.SendRequest<ProductResponse>(message);
        }

        async Task<IEnumerable<ProductResponse>> ICatalogApi.GetProducts()
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath(_settings.CatalogPath)
                .HttpMethod(HttpMethod.Get)
                .GetHttpMessage();
            return await base.SendRequest<IEnumerable<ProductResponse>>(message);
        }

        async Task<IEnumerable<ProductResponse>> ICatalogApi.GetProductsByCategory(string category)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                .SetPath($"{_settings.CatalogPath}/GetProductByCategory")
                .AddQueryString("category", category)
                .HttpMethod(HttpMethod.Get)
                .GetHttpMessage();
            return await base.SendRequest<IEnumerable<ProductResponse>>(message);
        }


    }
}
