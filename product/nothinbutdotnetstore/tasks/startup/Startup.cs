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
            var container = new BasicDependencyContainer(new BasicDependencyRegistry(all_factories));
            Container.facade_resolver = () => container;
            add_dependency_instance<DependencyContainer>(container);
        }

        static void configure_application_commands()
        {
            add_factory<ViewMainDepartments, ViewMainDepartments>();
        }

        static void configure_service_layer()
        {
            add_factory<Catalog, StubCatalog>();
        }

        static void configure_front_controller()
        {
            add_factory<FrontController, DefaultFrontController>();
            add_factory<IEnumerable<RequestCommand>,StubSetOfCommands>();
            add_factory<RequestFactory, StubRequestFactory>();
            add_factory<CommandRegistry, DefaultCommandRegistry>();
            add_factory<TemplateRegistry, StubTemplateRegistry>();
            add_factory<Renderer,DefaultRenderer>();
        }

        private static void add_dependency_instance<Contract>(Contract instance)
		{
            all_factories.Add(typeof(Contract), new BasicDependencyFactory(() => instance));
		}

        private static void add_factory<Contract,Implementation>()
		{
            all_factories.Add(typeof(Contract), new AutomaticDependencyFactory(Container.fetch.a<DependencyContainer>(), typeof(Implementation)));
		}

    }
}