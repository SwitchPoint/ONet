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

        public static string PickRandom(string[] Input)
        {
            IRandomGenerator rand = new SimpleRandom();
            return PickRandom(Input, rand);
        }

        public static string PickRandom(string[] Input, IRandomGenerator RandomGenerator)
        {
            return Input[RandomGenerator.Generate(Input.Length-1)];
            
        }

    }
}
