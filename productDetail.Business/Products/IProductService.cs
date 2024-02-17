using productDetail.Domain.Entities;

namespace productDetail.Business.Products
{
    public interface IProductService: IBaseService
    {
        Task<List<Product>> GetProduct(string category);
    }
}