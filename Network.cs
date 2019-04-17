using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwashSim_Network;

namespace SwashSim_RouteAssign
{
    public class Network
    {
        public void SpecifyUserEquilibriumNetworkInput(List<LinkData> SwashSimLinks, List<NodeData> SwashSimNodes)
        {
            NetworkSetup();
            LinksSetup(SwashSimLinks);
            ODdemandSetup();
        }

        private void NetworkSetup()
        {
            
            //set up network
            XXE_DataStructures.NetworkData network = new XXE_DataStructures.NetworkData();
            network.ConvCrit = 0.0005;
            network.MaxIterations = 100;
            network.FirstNetworkNode = 9;
            network.NumNodes = 12;
            network.NumZones = 4;
            network.NumODrecords = 12;
            network.NumTimePeriods = 1;
            network.TotalLinks = 20;
            network.TimePeriodType = XXE_DataStructures.TimePeriod.Single;
            
            
        }

        private void LinksSetup(List<LinkData> SwashSimLinks)
        {
            //specify links
            List<XXE_DataStructures.LinkData> links = new List<XXE_DataStructures.LinkData>();
            links.Add(new XXE_DataStructures.LinkData());
            XXE_DataStructures.LinkData link = new XXE_DataStructures.LinkData();
            link.FromNode = 1;
        }

        private void ODdemandSetup()
        {
            //specify OD data
            List<XXE_DataStructures.ODdata> OD = new List<XXE_DataStructures.ODdata>();
        }

    }
}
