using DataAccess.Context;
using DataAccess.Repositories;
using Logic.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Data.Entity;
using System.Linq;

namespace CompositionRoot
{
	public class DependencyConfig
	{
		private const string RepositoryNamespace = "DataAccess.Repositories";
		private const string ServiceNamespace = "Logic.Services";

		public static Container RegisterDependencies()
		{
			var container = RegisterDependencyContainer();
			container.Verify();
			return container;
		}

		private static Container RegisterDependencyContainer()
		{
			var container = new Container();

			// DataAccess
			container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
			container.Register<DbContext, MyRetailContext>(Lifestyle.Scoped);

			// Repositories
			var repositoryAssembly = typeof(BootstrapRepository).Assembly;
			var repositoryRegistrations = repositoryAssembly
				.GetExportedTypes()
				.Where(type => type.Namespace == RepositoryNamespace && type.GetInterfaces().Any(i => i.Assembly == type.Assembly))
				.Select(type => new
				{
					Interface = type.GetInterfaces().SingleOrDefault(),
					Implementation = type
				});
			foreach (var reg in repositoryRegistrations)
			{
				container.Register(reg.Interface, reg.Implementation, Lifestyle.Transient);
			}

			// Services
			var serviceAssembly = typeof(BootstrapService).Assembly;
			var serviceRegistrations = serviceAssembly
				.GetExportedTypes()
				.Where(type => type.Namespace == ServiceNamespace && type.GetInterfaces().Any())
				.Select(type => new
				{
					Interface = type.GetInterfaces().Single(),
					Implementation = type
				});
			foreach (var reg in serviceRegistrations)
			{
				container.Register(reg.Interface, reg.Implementation, Lifestyle.Transient);
			}

			return container;
		}
	}
}
