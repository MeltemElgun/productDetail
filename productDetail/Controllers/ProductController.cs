using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productDetail.Business.Products;
using productDetail.Domain.Entities;

namespace productDetail.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        

        [HttpGet("{category}")]
        

        public async Task<ActionResult<List<Product>>> GetProduct(string category) {

            try
            {
                List<Product> productResponse = await _productService.GetProduct(category);
               
                return productResponse;
            }
            catch (System.Exception e)
            {
                throw e;
            }

        }

    }
}
