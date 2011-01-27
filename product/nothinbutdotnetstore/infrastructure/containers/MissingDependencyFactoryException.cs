using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class MissingDependencyFactoryException: Exception
    {
        public MissingDependencyFactoryException(Type type, Exception exception) : base(string.Empty, exception)
        {
            type_that_has_not_factory_to_create_it = type;
        }

        public Type type_that_has_not_factory_to_create_it { get; set; }
    }
}