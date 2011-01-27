using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface DependencyContainer
    {
        Dependency a<Dependency>();
        object a(Type dependency);
    }
}