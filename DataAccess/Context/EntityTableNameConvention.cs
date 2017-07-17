using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess.Context
{
	internal class EntityTableNameConvention : Convention
	{
		public EntityTableNameConvention()
		{
			// Find database tables automatically
			Types().Configure(t => t.ToTable(GetTableName(t.ClrType)));
		}

		private static string GetTableName(Type type)
		{
			string name = type.Name;
			return name.EndsWith("Entity")
				? name.Substring(0, name.Length - "Entity".Length)
				: name;
		}
	}
}
