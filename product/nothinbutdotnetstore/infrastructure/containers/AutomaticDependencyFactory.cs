using System;
using System.Reflection;

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
            var constructor_infos = type.GetConstructors();
            int foo = 0;
            ConstructorInfo the_constructor = null;
            foreach (var constructor_info in constructor_infos)
            {
                var length = constructor_info.GetParameters().Length;
                if (length > foo)
                {
                    the_constructor = constructor_info;
                    foo = length;
                }
            }
            var parameter_infos = the_constructor.GetParameters();
            object[] objects;
            objects = new object[foo];
            int i = 0;
            foreach (var parameter_info in parameter_infos)
            {
                Type parameter_type = parameter_info.ParameterType;
                objects[i] = container.a(parameter_type);
                i++;
            }
            return the_constructor.Invoke(objects);

        }
    }
}