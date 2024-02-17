using productDetail.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace productDetail.Business.Categories
{
    public class CategoriesService : BaseService, ICategoriesService
    {
        private readonly HttpClient client;

        public CategoriesService()
        {
            client = new HttpClient();

        }

        public async Task<List<string>> GetCategories()
        {
            var responseString = await client.GetStringAsync("https://dummyjson.com/products/categories");
            var response = JsonSerializer.Deserialize<List<string>>(responseString);
            return response ?? new List<string>();
        }
    }
}
