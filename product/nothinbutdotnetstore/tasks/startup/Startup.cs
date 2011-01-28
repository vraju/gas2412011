using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
		private static IDictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();

        public static void run()
        {
            configure_core_components();
			configure_front_controller();
            configure_service_layer();
        	configure_application_commands();
        }

        static void configure_core_components()
        {
            Container.facade_resolver = () => new BasicDependencyContainer(new BasicDependencyRegistry(all_factories));
        }

        static void configure_application_commands()
        {
            add_factory<ViewMainDepartments>(() => new ViewMainDepartments(Container.fetch.a<Catalog>(), 
                Container.fetch.a<Renderer>()));
        }

        static void configure_service_layer()
        {
            add_factory<Catalog>(() => new StubCatalog());
        }

        static void configure_front_controller()
        {
            var template_registry = new StubTemplateRegistry();
            var renderer = new DefaultRenderer(template_registry);

            var default_command_registry = new DefaultCommandRegistry(new StubSetOfCommands());

            add_factory<FrontController>(() => new DefaultFrontController(default_command_registry));
            add_factory<RequestFactory>(() => new StubRequestFactory());
            add_factory<CommandRegistry>(() => default_command_registry);
            add_factory<TemplateRegistry>(() => template_registry);
            add_factory<Renderer>(() => renderer);
        }

        private static void add_factory<TKey>(Func<object> instance)
		{
			all_factories.Add(typeof(TKey), new BasicDependencyFactory(() => instance()));
		}

    }
}