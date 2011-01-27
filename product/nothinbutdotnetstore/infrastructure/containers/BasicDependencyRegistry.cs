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

        public DependencyFactory get_the_factory_for(Type dependency)
        {
            return Execute<DependencyFactory>
                .run(() => factories[dependency],
                e => new MissingDependencyFactoryException(dependency, e));
        }

    }
}