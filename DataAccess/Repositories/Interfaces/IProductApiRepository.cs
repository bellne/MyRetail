using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
	public interface IProductApiRepository
	{
		Task<ProductEntity> GetProduct(long id);
		Task<List<ProductEntity>> GetProducts();
	}
}
