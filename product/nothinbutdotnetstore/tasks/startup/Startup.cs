using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {

        public static void run()
        {
            var all_factories = new Dictionary<Type,DependencyFactory>();
            Container.facade_resolver = () => new BasicDependencyContainer(
                new BasicDependencyRegistry(all_factories));

            //your code below here
            

        }
    }
}