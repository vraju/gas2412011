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

		private static Dictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();
        public static void run()
        {

            Container.facade_resolver = () => new BasicDependencyContainer(new BasicDependencyRegistry(all_factories));

            //your code below here
            var default_command_registry = new DefaultCommandRegistry(new StubSetOfCommands());

            TemplateRegistry template_registry = new StubTemplateRegistry();
            Renderer renderer = new DefaultRenderer(template_registry);
            Catalog repository = new StubCatalog();
			
			add_factory<FrontController>(new DefaultFrontController(default_command_registry));
			add_factory<RequestFactory>(new StubRequestFactory());
			add_factory<CommandRegistry>(default_command_registry);
			add_factory<TemplateRegistry>(template_registry);
			add_factory<Renderer>(renderer);
			add_factory<Catalog>(repository);
        	add_factory<ViewMainDepartments>(new ViewMainDepartments(repository, renderer));

        }

		private static void add_factory<TKey>(Object value)
		{
			all_factories.Add(typeof(TKey), new BasicDependencyFactory(() => value));
		}

    }
}