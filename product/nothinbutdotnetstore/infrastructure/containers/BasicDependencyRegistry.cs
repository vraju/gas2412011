using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
	public class BasicDependencyRegistry : DependencyRegistry
	{
		public DependencyFactory get_the_factory_for<DependencyContract>()
		{
			throw new NotImplementedException();
		}
	}
}