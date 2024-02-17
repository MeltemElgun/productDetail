
namespace productDetail.Business.Categories
{
    public interface ICategoriesService:IBaseService
    {
        Task<List<string>> GetCategories();
    }
}