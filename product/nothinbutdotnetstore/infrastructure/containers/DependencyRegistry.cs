using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface DependencyRegistry
    {
        Factory<T> lookup<T>();
    }
}
