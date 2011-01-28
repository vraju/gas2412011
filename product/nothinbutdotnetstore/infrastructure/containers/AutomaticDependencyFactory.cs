using System;
using System.Reflection;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class AutomaticDependencyFactory : DependencyFactory
    {
        DependencyContainer container;
        Type type;

        public AutomaticDependencyFactory(DependencyContainer container, Type type)
        {
            this.container = container;
            this.type = type;
        }

        public object create()
        {
            var greediest_constructor = type.GetConstructors()
                .OrderByDescending(x => x.GetParameters().Count())
                .First();

            var arguments = greediest_constructor.GetParameters()
                .Select(x => container.a(x.ParameterType));

            return greediest_constructor.Invoke(arguments.ToArray());

        }
    }
}