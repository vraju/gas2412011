using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface DependencyRegistry
    {
        DependencyFactory get_the_factory_for(Type dependency_type);
    }
}