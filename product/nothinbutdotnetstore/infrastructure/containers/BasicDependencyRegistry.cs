using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class BasicDependencyRegistry : DependencyRegistry
    {
        IDictionary<Type, DependencyFactory> factories;

        public BasicDependencyRegistry(IDictionary<Type, DependencyFactory> factories)
        {
            this.factories = factories;
        }

        public DependencyFactory get_the_factory_for<DependencyContract>()
        {
            try
            {
                return factories[typeof(DependencyContract)];
            }catch(Exception ex)
            {
                throw new MissingDependencyFactoryException(typeof(DependencyContract),ex);
            }
        }
    }
}