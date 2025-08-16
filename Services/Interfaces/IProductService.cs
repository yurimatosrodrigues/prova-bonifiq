using ProvaPub.Models;

namespace ProvaPub.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductList> ListProducts(int page);
    }
}
