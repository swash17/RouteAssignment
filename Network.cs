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
        List<List<int>> UEnetworkPathList = new List<List<int>>();
        List<List<int>> SwashSimPathLists = new List<List<int>>();

        public void SpecifyUserEquilibriumNetworkInput(List<LinkData> SwashSimLinks, List<NodeData> SwashSimNodes,XXE_DataStructures.NetworkData networkXXE, List<XXE_DataStructures.LinkData> linksXXE, List<XXE_DataStructures.ODdata> ODXXE)
        {
            NetworkSetup(networkXXE);
            LinksSetup(linksXXE);
            ODdemandSetup(ODXXE);
            PathsSetup();
        }


        public int DetermineEntryNode(int OrigZone)
        {
            int EntryNodeSwashSim = 0;
            switch (OrigZone)
            {
                case 1:
                    EntryNodeSwashSim = 701;
                    break;
                case 2:
                    EntryNodeSwashSim = 702;
                    break;
                case 3:
                    EntryNodeSwashSim = 704;
                    break;
                case 4:
                    EntryNodeSwashSim = 703;
                    break;
            }
            return EntryNodeSwashSim;
        }

        public List<int> DeterminePathNodes(List<int> PathNodes)
        {
            List<int> PathNodesSwashSim = new List<int>();
            bool match = false;
            for(int pathID =0; pathID < UEnetworkPathList.Count; pathID++)
            {
                for(int i = 0; i<PathNodes.Count;i++)
                {
                    if(PathNodes[i] != UEnetworkPathList[pathID][i])
                    {
                        match = false;
                        break;
                    }
                    match = true;
                }
                if(match == true)
                {
                    PathNodesSwashSim = SwashSimPathLists[pathID];
                    break;
                }
            }
            return PathNodesSwashSim;
        }

        private void NetworkSetup(XXE_DataStructures.NetworkData network)
        {
            //XXE network input
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
            //UE links input for XXE
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
            //OD demand input for XXE
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

        private void PathsSetup()
        {
            //UE network paths
            UEnetworkPathList.Add(new List<int> { 9, 10 });
            UEnetworkPathList.Add(new List<int> { 9, 11, 12, 10 });
            UEnetworkPathList.Add(new List<int> { 9, 11 });
            UEnetworkPathList.Add(new List<int> { 9, 10, 12, 11 });
            UEnetworkPathList.Add(new List<int> { 9, 10, 12 });
            UEnetworkPathList.Add(new List<int> { 9, 11, 12 });
            UEnetworkPathList.Add(new List<int> { 10, 9 });
            UEnetworkPathList.Add(new List<int> { 10, 12, 11, 9 });
            UEnetworkPathList.Add(new List<int> { 10, 12, 11 });
            UEnetworkPathList.Add(new List<int> { 10, 9, 11 });
            UEnetworkPathList.Add(new List<int> { 10, 12 });
            UEnetworkPathList.Add(new List<int> { 10, 9, 11, 12 });
            UEnetworkPathList.Add(new List<int> { 11, 9 });
            UEnetworkPathList.Add(new List<int> { 11, 12, 10, 9 });
            UEnetworkPathList.Add(new List<int> { 11, 12, 10 });
            UEnetworkPathList.Add(new List<int> { 11, 9, 10 });
            UEnetworkPathList.Add(new List<int> { 11, 12 });
            UEnetworkPathList.Add(new List<int> { 11, 9, 10, 12 });
            UEnetworkPathList.Add(new List<int> { 12, 11, 9 });
            UEnetworkPathList.Add(new List<int> { 12, 10, 9 });
            UEnetworkPathList.Add(new List<int> { 12, 10 });
            UEnetworkPathList.Add(new List<int> { 12, 11, 9, 10 });
            UEnetworkPathList.Add(new List<int> { 12, 11 });
            UEnetworkPathList.Add(new List<int> { 12, 10, 9, 11 });

            //SwashSim network paths
            SwashSimPathLists.Add(new List<int> { 8, 7, 4, 16, 13, 12, 802 });
            SwashSimPathLists.Add(new List<int> { 8, 7, 6, 27, 30, 24, 19, 14, 13, 12, 802 });
            SwashSimPathLists.Add(new List<int> { 8, 7, 6, 27, 26, 25, 804 });
            SwashSimPathLists.Add(new List<int> { 8, 7, 4, 16, 15, 18, 17, 29, 26, 25, 804 });
            SwashSimPathLists.Add(new List<int> { 8, 7, 4, 16, 15, 18, 23, 22, 803 });
            SwashSimPathLists.Add(new List<int> { 8, 7, 6, 27, 30, 24, 23, 22, 803 });
            SwashSimPathLists.Add(new List<int> { 11, 10, 9, 3, 2, 1, 801 });
            SwashSimPathLists.Add(new List<int> { 11, 10, 15, 18, 17, 29, 28, 5, 2, 1, 801 });
            SwashSimPathLists.Add(new List<int> { 11, 10, 15, 18, 17, 29, 26, 25, 804 });
            SwashSimPathLists.Add(new List<int> { 11, 10, 9, 3, 6, 27, 26, 25, 804 });
            SwashSimPathLists.Add(new List<int> { 11, 10, 15, 18, 23, 22, 803 });
            SwashSimPathLists.Add(new List<int> { 11, 10, 9, 3, 6, 27, 30, 24, 23, 22, 803 });
            SwashSimPathLists.Add(new List<int> { 32, 31, 28, 5, 2, 1, 801 });
            SwashSimPathLists.Add(new List<int> { 32, 31, 30, 24, 19, 14, 9, 3, 2, 1, 801 });
            SwashSimPathLists.Add(new List<int> { 32, 31, 30, 24, 19, 14, 13, 12, 802 });
            SwashSimPathLists.Add(new List<int> { 32, 31, 28, 5, 4, 16, 13, 12, 802 });
            SwashSimPathLists.Add(new List<int> { 32, 31, 30, 24, 23, 22, 803 });
            SwashSimPathLists.Add(new List<int> { 32, 31, 28, 5, 4, 16, 15, 18, 23, 22, 803 });
            SwashSimPathLists.Add(new List<int> { 21, 20, 17, 29, 28, 5, 2, 1, 801 });
            SwashSimPathLists.Add(new List<int> { 21, 20, 19, 14, 9, 3, 2, 1, 801 });
            SwashSimPathLists.Add(new List<int> { 21, 20, 19, 14, 13, 12, 802 });
            SwashSimPathLists.Add(new List<int> { 21, 20, 17, 29, 28, 5, 4, 16, 13, 12, 802 });
            SwashSimPathLists.Add(new List<int> { 21, 20, 17, 29, 26, 25, 804 });
            SwashSimPathLists.Add(new List<int> { 21, 20, 19, 14, 9, 3, 6, 27, 26, 25, 804 });
        }
    }
}
