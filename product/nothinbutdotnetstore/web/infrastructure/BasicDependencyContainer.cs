using System;
using System.Threading;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.web.infrastructure
{
    public class BasicDependencyContainer : DependencyContainer
    {
        readonly DependencyRegistry dependency_registry;

        public BasicDependencyContainer(DependencyRegistry dependency_registry)
        {
            this.dependency_registry = dependency_registry;
        }

        public Dependency a<Dependency>() 
        {
            var factory = dependency_registry.lookup<Dependency>();
            try
            {
                return (Dependency) factory.create();
             
            }catch(Exception ex){

                 throw new DependencyCreationException(typeof(Dependency), ex,"object creation failed");

            }
        }
    }
}