using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFCRM.Plugins
{
    public class CreateAccountPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            Entity Target = (Entity)context.InputParameters["Target"];

            MefDependencyResolver resolver = new MefDependencyResolver(service);

            IAccountCreator accountCreator = resolver.GetInstance<IAccountCreator>();

            accountCreator.CreateAccount();
        }
    }
}
