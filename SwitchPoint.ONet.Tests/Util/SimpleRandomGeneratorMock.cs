using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Tests.Util
{
    class SimpleRandomGeneratorMock : SwitchPoint.ONet.Util.IRandomGenerator
    {
        int expected;
        public SimpleRandomGeneratorMock(int Expected)
        {
            expected = Expected;
        }

        public int Generate(int Max)
        {
            return expected;
        }
    }
}
