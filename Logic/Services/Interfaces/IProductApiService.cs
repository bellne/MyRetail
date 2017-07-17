using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
	public interface IProductApiService
	{
		Task<ProductEntity> GetProduct(long id);
		Task<List<ProductEntity>> GetProducts();
	}
}
