﻿using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFCRM.Plugins
{
	/* Responsible for Creating an Account in CRM */
    interface IAccountCreator
    {
        void CreateAccount();
    }
}
