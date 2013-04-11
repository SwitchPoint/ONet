using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.File
{
    public class Reader
    {
        public static String ReadAll(string File)
        {
            String AllContent = "";
            
            using (StreamReader sr = new StreamReader(File))
            {
                AllContent = sr.ReadToEnd();

            }
            
            return AllContent;
        }
    }
}
