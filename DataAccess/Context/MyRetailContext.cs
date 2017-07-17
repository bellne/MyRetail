using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace DataAccess.Context
{
	public class MyRetailContext : DbContext
	{
		public MyRetailContext() : base("MyRetailContext")
		{
			Database.SetInitializer<MyRetailContext>(null);
#if DEBUG
			Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Don't pluralize table names
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			// Entity names are Table Name + "Entity"
			modelBuilder.Conventions.Add<EntityTableNameConvention>();

			// All strings are varchar and are not nullable
			modelBuilder.Properties<string>().Configure(e => e.
				IsUnicode(false).
				IsRequired());

			// Decimals are 19,4 by default
			modelBuilder.Properties<decimal>().Configure(e => e
				.HasPrecision(19, 4));

			// Look in DataAccess for all classes that inherit from EntityTypeConfiguration
			modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
