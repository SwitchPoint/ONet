using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Util
{
    public class StringUtils
    {
        public static string[] SplitNewLines(string Input)
        {
            return Input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        }

    }
}
