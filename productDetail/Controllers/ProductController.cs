using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productDetail.Business.Categories;
using productDetail.Business.Products;
using productDetail.Domain.Entities;
using productDetail.Domain.Exceptions;

namespace productDetail.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoriesService _categoriesService;
       
        public ProductController(IProductService productService, ICategoriesService categoriesService)
        {
            _productService = productService;
            _categoriesService = categoriesService;


        }

        [HttpGet("{category}")]

        public async Task<ActionResult<List<Product>>> GetProduct(string category) {
            if (string.IsNullOrEmpty(category))
            { 
                throw new NullReferenceException();
            }

            List<string> availableCategories = await _categoriesService.GetCategories();

            if (!availableCategories.Contains(category))
            {
                throw new ArgumentException();
            }
            try
            {
                List<Product> productResponse = await _productService.GetProduct(category);
                return productResponse;
            }
            catch (Exception )
            {
                throw new CustomException("Error calling API");
            }

        }

    }
}
