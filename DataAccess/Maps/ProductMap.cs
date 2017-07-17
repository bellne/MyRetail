using Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Maps
{
	public class ProductMap : EntityTypeConfiguration<ProductEntity>
	{
		public ProductMap()
		{
			Property(x => x.Id)
				.IsRequired();
			Property(x => x.Name)
				.IsRequired();
			Property(x => x.CategoryTypeId)
				.IsRequired();
			Property(x => x.Price)
				.IsRequired();
			Property(x => x.Sku)
				.IsRequired();
			Property(x => x.LastUpdated)
				.IsRequired();
		}
	}
}
