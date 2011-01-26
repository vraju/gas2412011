using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stubs;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.web.core
{
    public class ViewRepositoryData<ItemType> : ApplicationCommand
    {
        Catalog repository;
        Renderer renderer;
        Getter getter;
        ItemType parent;

        public delegate IEnumerable<ItemType> Getter(ItemType parent);
        public ViewRepositoryData(Catalog repository, Renderer renderer, Getter getter, ItemType parent)
        {
            this.repository = repository;
            this.renderer = renderer;
            this.getter = getter;
            this.parent = parent;
        }

        public void run(Request request)
        {
            //renderer.display(repository.get_departments_in(request.map<Department>()));
            renderer.display(getter(parent));
        }
    }
}
