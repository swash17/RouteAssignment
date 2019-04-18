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
        public void SpecifyUserEquilibriumNetworkInput(List<LinkData> SwashSimLinks, List<NodeData> SwashSimNodes,XXE_DataStructures.NetworkData networkXXE, List<XXE_DataStructures.LinkData> linksXXE, List<XXE_DataStructures.ODdata> ODXXE)
        {
            NetworkSetup(networkXXE);
            LinksSetup(linksXXE);
            ODdemandSetup(ODXXE);
        }

        private void NetworkSetup(XXE_DataStructures.NetworkData network)
        {          
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

        private void LinksSetup(List<XXE_DataStructures.LinkData> links)
        {       
            links.Add(new XXE_DataStructures.LinkData());
            links.Add(new XXE_DataStructures.LinkData(1, 9, 0.5, 0,1000, 40,"1", false));            
            links.Add(new XXE_DataStructures.LinkData(2, 10, 0.5, 0, 1000, 40, "2", false));
            links.Add(new XXE_DataStructures.LinkData(3, 11, 0.5, 0, 1000, 40, "3", false));
            links.Add(new XXE_DataStructures.LinkData(4, 12, 0.5, 0, 1000, 40, "4", false));
            links.Add(new XXE_DataStructures.LinkData(5, 9, 0.5, 0, 1000, 40, "5", false));
            links.Add(new XXE_DataStructures.LinkData(6, 10, 0.5, 0, 1000, 40, "6", false));
            links.Add(new XXE_DataStructures.LinkData(7, 11, 0.5, 0, 1000, 40, "7", false));
            links.Add(new XXE_DataStructures.LinkData(8, 12, 0.5, 0, 1000, 40, "8", false));
            links.Add(new XXE_DataStructures.LinkData(9, 5, 0.5, 0, 1000, 40, "9", false));
            links.Add(new XXE_DataStructures.LinkData(9, 10, 2, 0, 1000, 40, "10", false));
            links.Add(new XXE_DataStructures.LinkData(9, 11, 2, 0, 1000, 40, "11", false));
            links.Add(new XXE_DataStructures.LinkData(10, 6, 0.5, 0, 1000, 40, "12", false));
            links.Add(new XXE_DataStructures.LinkData(10, 9, 2, 0, 1000, 40, "13", false));
            links.Add(new XXE_DataStructures.LinkData(10, 12, 2, 0, 1000, 40, "14", false));
            links.Add(new XXE_DataStructures.LinkData(11, 7, 0.5, 0, 1000, 40, "15", false));
            links.Add(new XXE_DataStructures.LinkData(11, 9, 2, 0, 1000, 40, "16", false));
            links.Add(new XXE_DataStructures.LinkData(11, 12, 2, 0, 1000, 40, "17", false));
            links.Add(new XXE_DataStructures.LinkData(12, 8, 0.5, 0, 1000, 40, "18", false));
            links.Add(new XXE_DataStructures.LinkData(12, 10, 2, 0, 1000, 40, "19", false));
            links.Add(new XXE_DataStructures.LinkData(12, 11, 2, 0, 1000, 40, "20", false));
            for(int n =1; n< links.Count; n++)
            {
                links[n].Capacity[0] = 1000;
                links[n].Capacity[1] = 1000;
            }
        }

        private void ODdemandSetup(List<XXE_DataStructures.ODdata> OD)
        {
            OD.Add(new XXE_DataStructures.ODdata());
            OD.Add(new XXE_DataStructures.ODdata(1, 2, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(1, 3, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(1, 4, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(2, 1, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(2, 3, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(2, 4, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(3, 1, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(3, 2, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(3, 4, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(4, 1, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(4, 2, 1000, 1000));
            OD.Add(new XXE_DataStructures.ODdata(4, 3, 1000, 1000));
        }

    }
}
