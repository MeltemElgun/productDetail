using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productDetail.Business.Categories;
using productDetail.Business.Products;
using productDetail.Domain.Entities;

namespace productDetail.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }




        [HttpGet]

        public async Task<ActionResult<List<string>>> GetCategories()
        {
            try
            {
                List<string> productResponse = await _categoriesService.GetCategories();
                return productResponse;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
