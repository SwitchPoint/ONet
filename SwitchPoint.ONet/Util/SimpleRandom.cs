using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Util
{
    class SimpleRandom : IRandomGenerator
    {

        public int Generate(int Max)
        {
            return (new Random()).Next(Max);
        }
    }
}
