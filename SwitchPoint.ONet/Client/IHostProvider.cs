using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Client
{
    interface IHostProvider
    {
        Network.Host GetRandomHost();
    }
}
