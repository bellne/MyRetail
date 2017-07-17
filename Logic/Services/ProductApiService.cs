using DataAccess.Repositories.Interfaces;
using Logic.Services.Interfaces;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Services
{
	public class ProductApiService : IProductApiService
	{
		private readonly IProductApiRepository _productApiRepository;

		public ProductApiService(IProductApiRepository productApiRepository)
		{
			_productApiRepository = productApiRepository;
		}

		public async Task<ProductEntity> GetProduct(long id)
		{
			return await _productApiRepository.GetProduct(id);
		}

		public async Task<List<ProductEntity>> GetProducts()
		{
			return await _productApiRepository.GetProducts();
		}
	}
}
