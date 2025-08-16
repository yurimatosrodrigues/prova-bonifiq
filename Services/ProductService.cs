using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
	public class ProductService : IProductService
	{
		IProductRepository _productRepository;
		int pageSize = 10;
		public ProductService(IProductRepository productRepository)
		{
            _productRepository = productRepository;
        }

		public async Task<ProductList> ListProducts(int page)
		{
            var productList = await _productRepository.GetAllPagingAsync(page, pageSize);

			return new ProductList() {
                Items = productList.Items,
                TotalCount = productList.TotalCount,
                HasNext = productList.HasNext
            };
		}

	}
}
