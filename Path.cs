using System;
using System.Collections.Generic;
using SwashSim_Network;
using XXE_Calculations;


namespace SwashSim_RouteAssign
{

    public class Path
    {
        private FloydGraph graph;
        private ushort[] idToindex;
        private uint[,] linkId;

        Network UEnetwork = new Network();

        public Path()
        {
            double test = 1;
        }
        
        public void CalcUEassignment(List<LinkData> SwashSimLinks, List<NodeData> SwashSimNodes)
        {
            
            XXE_DataStructures.NetworkData networkXXE = new XXE_DataStructures.NetworkData();
            List<XXE_DataStructures.LinkData> linksXXE = new List<XXE_DataStructures.LinkData>();
            List<XXE_DataStructures.ODdata> ODXXE = new List<XXE_DataStructures.ODdata>();
            UEnetwork.SpecifyUserEquilibriumNetworkInput(SwashSimLinks, SwashSimNodes, networkXXE, linksXXE,ODXXE);

            //Call XXE to perform User Equilibrium Traffic Assignment
            XXE_DataStructures.ProjectData project = new XXE_DataStructures.ProjectData();
            project.Type = XXE_DataStructures.ProjectType.BPRlinks;
            List<HCMCalc_Definitions.FreewayData> freewayFacilities = new List<HCMCalc_Definitions.FreewayData>();
            List<XXE_DataStructures.UserEquilibriumTimePeriodResult> resultsUE = new List<XXE_DataStructures.UserEquilibriumTimePeriodResult>();
            List<List<List<double>>> rampProportionList = new List<List<List<double>>>();
            Calculations.RunControl(project, networkXXE, linksXXE, freewayFacilities, ODXXE, resultsUE, rampProportionList);
            //Get one set of feasible path flow results
            List<XXE_DataStructures.PathData> PathFlowResults = Calculations.GetPathResults();

            DisplayPathFlowDataGridView(PathFlowResults);
        }

        private void PathAssignmentOutputForSwashSim(List<XXE_DataStructures.PathData> PathFlowResults)
        {

            List<object[]> PathAssignmentObjectList = new List<object[]>();
            object[] PathAssignmentObject;
            for (int path = 0; path < PathFlowResults.Count; path++)
            {
                PathAssignmentObject = new object[3];
                PathAssignmentObject[0] = UEnetwork.DetermineEntryNode(PathFlowResults[path].OrigZone);
                PathAssignmentObject[1] = UEnetwork.DeterminePathNodes(PathFlowResults[path].Nodes);
                PathAssignmentObject[2] = CalculatePathProbability(PathFlowResults[path].OrigZone, PathFlowResults[path].Nodes);
                PathAssignmentObjectList.Add(PathAssignmentObject);
            }
        }

        private double CalculatePathProbability(int origZone, List<int> pathNodes)
        {
            double PathProb = new double();

            return PathProb;
        }
           

        private void DisplayPathFlowDataGridView(List<XXE_DataStructures.PathData> PathFlowResults)
        {
            UserEquilibriumResults myUEresultsForm = new UserEquilibriumResults(PathFlowResults);
            myUEresultsForm.Show();
        }



        public void OldCode(List<LinkData> links, List<NodeData> nodes)
        {
            UInt16 size = (ushort)nodes.Count;
            float[,] matrix = new float[size, size];
            linkId = new uint[size, size];
            idToindex = new ushort[nodes[nodes.Count - 1].Id + 1];

            for (UInt16 i = 0; i < size; i++)
            {
                for (UInt16 j = 0; j < size; j++)
                {
                    matrix[i, j] = float.MaxValue;
                    linkId[i, j] = uint.MaxValue;
                }
            }

            for (ushort i = 0; i < idToindex.Length; i++)
            {
                idToindex[i] = ushort.MaxValue;
            }

            foreach (NodeData n in nodes)
            {
                idToindex[n.Id] = n.ListIndex;
            }

            foreach (LinkData l in links)
            {
                matrix[idToindex[l.NodeIdUp], idToindex[l.NodeIdDown]] = l.Length;
                linkId[idToindex[l.NodeIdUp], idToindex[l.NodeIdDown]] = l.Id;
            }
            graph = new FloydGraph(size, matrix);
        }

        public void PathGeneration(EntryNode _Origin, ExitNode _Destination, UInt16 _Type, ref List<ushort> _NodesIndex, ref List<uint> _LinksID, ref float _Dis)
        {
            if ( _Type == 1 )     //Shortest Path
            {
                graph.FindShortestPath(_Origin.ListIndex, _Destination.ListIndex);
                _NodesIndex = graph.Result;
                _Dis = graph.Dist[_Origin.ListIndex, _Destination.ListIndex];
                for (ushort i = 0; i < _NodesIndex.Count - 1; i++)
                {
                    _LinksID.Add(linkId[_NodesIndex[i], _NodesIndex[i + 1]]);
                }
            }
            else                //Other Path Schemes
            {
                graph.FindShortestPath(_Origin.ListIndex, _Destination.ListIndex);
                _NodesIndex = graph.Result;
                _Dis = graph.Dist[_Origin.ListIndex, _Destination.ListIndex];
                for (ushort i = 0; i < _NodesIndex.Count - 1; i++)
                {
                    _LinksID.Add(linkId[_NodesIndex[i], _NodesIndex[i + 1]]);
                }
            }
        }


        public List<MovementDirectionCode> GetPath(EntryNode _Origin, ExitNode _Destination)
        {
            NetworkData network = new NetworkData();
            List<NodeData> nodes = new List<NodeData>();
            List<LinkData> links = new List<LinkData>();

            //NetworkTopologyParking.CreateNetworkTopology(network, node, link);

            //Path p = new Path(link, node);
            Path p = new Path();
            p.CalcUEassignment(links, nodes);

            List<ushort> _nodesIndex = new List<ushort>();
            float _dis = 0;
            List<ushort> _pathNodes = new List<ushort>();
            List<uint> _pathLinks = new List<uint>();
            List<MovementDirectionCode> TurningMovementList = new List<MovementDirectionCode>();

            p.PathGeneration(_Origin, _Destination, 1, ref _nodesIndex, ref _pathLinks, ref _dis);
            foreach (ushort index_i in _nodesIndex)
            {
                _pathNodes.Add(nodes[index_i].Id);
            }

            for (int i = 1; i < _pathLinks.Count; i++)
            {
                if (links[i - 1].DownstreamLinkIds[0] == links[i].Id)
                    TurningMovementList.Add(MovementDirectionCode.Left);
                else
                    if (links[i - 1].DownstreamLinkIds[1] == links[i].Id)
                    TurningMovementList.Add(MovementDirectionCode.Through);
                else
                    TurningMovementList.Add(MovementDirectionCode.Right);
            }

            return TurningMovementList;
        }

    }
}
