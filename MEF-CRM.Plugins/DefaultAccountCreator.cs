using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFCRM.Plugins
{
    [Export(typeof(IAccountCreator))]
    public class DefaultAccountCreator: IAccountCreator
    {
        [Import]
        public IOrganizationService Service { get; set; }

        public void CreateAccount()
        {
            Service.Create(new Entity("account"));
        }
    }
}
