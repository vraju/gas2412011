using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

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
            var stub_set_of_commands = new StubSetOfCommands();
            var default_command_registry = new DefaultCommandRegistry(stub_set_of_commands);
            var default_front_controller = new DefaultFrontController(default_command_registry);
            var stub_request_factory = new StubRequestFactory();

            all_factories.Add(typeof(FrontController), new BasicDependencyFactory(() => default_front_controller));
            all_factories.Add(typeof(RequestFactory), new BasicDependencyFactory(() => stub_request_factory));
            all_factories.Add(typeof(CommandRegistry), new BasicDependencyFactory(() => default_command_registry));


        }
    }
}