using Models.Enums;
using System;

namespace Models.Entities
{
	public class ProductEntity
	{
		public long Id { get; set; }
		public string Sku { get; set; }
		public string Name { get; set; }
		public CategoryType CategoryTypeId { get; set; }
		public DateTime LastUpdated { get; set; }
		public decimal Price { get; set; }
	}
}
