using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        public IEnumerator<RequestCommand> GetEnumerator()
        {
            TemplateRegistry template_registry = new StubTemplateRegistry();
            Renderer renderer = new DefaultRenderer(template_registry);
            Catalog repository = new StubCatalog();
            yield return new DefaultRequestCommand((x) => true, new ViewMainDepartments(repository, renderer));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}