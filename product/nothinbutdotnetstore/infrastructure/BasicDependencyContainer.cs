using System;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure
{
    public class BasicDependencyContainer : DependencyContainer
    {
        DependencyRegistry dependency_registry;

        public BasicDependencyContainer(DependencyRegistry dependency_registry)
        {
            this.dependency_registry = dependency_registry;
        }

        public Dependency a<Dependency>()
        {
            return (Dependency)a(typeof(Dependency));
        }

        public object a(Type dependency)
        {
            var factory = dependency_registry.get_the_factory_for(dependency);
            return Execute<object>.run(() => factory.create(),
                                                          e => new DependencyCreationException(dependency, e));
		}
    }
}

