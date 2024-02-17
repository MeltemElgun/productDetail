using Microsoft.Extensions.Logging;
using productDetail.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace productDetail.Business.Products
{
    public class ProductService : BaseService, IProductService
    {
        private readonly HttpClient client;

        public ProductService()
        {
            client = new HttpClient();

        }

        public async Task<List<Product>> GetProduct(string category)
        {
            
            var apiUrl = $"https://dummyjson.com/products/category/{category}";

            var responseString = await client.GetStringAsync(apiUrl);

            var response = JsonSerializer.Deserialize<ProductRoot>(responseString);
            return response.products ?? new List<Product> () ;
        }


    }
}
