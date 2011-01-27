using System;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.web.infrastructure
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
            var factory = dependency_registry.get_the_factory_for<Dependency>();
            try
            {
                return (Dependency) factory.create();
            }
            catch (Exception exception)
            {
                throw new DependencyCreationException(typeof(Dependency), exception);
            }
        }
    }
}