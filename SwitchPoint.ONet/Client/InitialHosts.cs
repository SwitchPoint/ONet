using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPoint.ONet.Client
{
    public class InitialHosts : IHostProvider
    {
        private String InitialHostsFile;
        private Util.IRandomGenerator Generator;


        public InitialHosts(String File)
        {
            InitialHostsFile = File;
        }

        public InitialHosts(String File, Util.IRandomGenerator Random)
        {
            InitialHostsFile = File;
            Generator = Random;
        }




        public Network.Host GetRandomHost()
        {
            String FileContents = File.Reader.ReadAll(InitialHostsFile);
            String[] AllHosts = Util.StringUtils.SplitNewLines(FileContents);

            if (Generator == null)
            {
                Generator = new Util.SimpleRandom();
            }



            String SelectedHost = Util.StringUtils.PickRandom(AllHosts,Generator);

            return new Network.Host(SelectedHost);
        }
    }
}
