using DataAccess.Repositories.Interfaces;
using Models.Entities;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApi.OutputCache.V2;

namespace DataAccess.Repositories
{
	public class ProductApiRepository : IProductApiRepository
	{
		private readonly DbContext _context;

		public ProductApiRepository(DbContext context)
		{
			_context = context;
		}

       
		public async Task<ProductEntity> GetProduct(long id)
		{
			//return new ProductEntity
			//{
			//	Price = 199.99M,
			//	Id = 2,
			//	Category = CategoryType.Baby,
			//	Name = "Stroller",
			//	LastUpdated = DateTime.Now,
			//	Sku = "xds97s"
			//};
			return await _context.Set<ProductEntity>().FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<List<ProductEntity>> GetProducts()
		{
			//return new List<ProductEntity>
			//{
			//	new ProductEntity
			//	{
			//		Price = 199.99M,
			//		Id = 2,
			//		CategoryTypeId = CategoryType.Baby,
			//		Name = "Stroller",
			//		LastUpdated = DateTime.Now,
			//		Sku = "xds97s"
			//	},
			//	new ProductEntity
			//	{
			//		Price = 129.99M,
			//		Id = 1,
   //                 CategoryTypeId = CategoryType.Toys,
			//		Name = "Sega Genesis",
			//		LastUpdated = DateTime.Now,
			//		Sku = "eoir832"
			//	}
			//};
			return await _context.Set<ProductEntity>().ToListAsync();
		}
	}
}
