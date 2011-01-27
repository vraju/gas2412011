using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class MissingDependencyFactoryException: Exception
    {
        public Type type_that_has_not_factory_to_create_it { get; set; }
    }
}