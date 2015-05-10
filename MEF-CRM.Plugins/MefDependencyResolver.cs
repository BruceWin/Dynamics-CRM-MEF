using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace MEFCRM.Plugins
{
    public class MefDependencyResolver
    {
        private CompositionContainer container;

        public MefDependencyResolver(IOrganizationService service)
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            container = new CompositionContainer(catalog);
            container.ComposeExportedValue<IOrganizationService>(service);
        }

        public T GetInstance<T>()
        {
            var instance = container.GetExport<T>();
            if (instance != null)
                return instance.Value;
            return default(T);
        }
    }
}
