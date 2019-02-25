﻿using System;
using System.Collections.Generic;
using SwashSim_Network;



namespace SwashSim_RouteAssign
{
    public class Path
    {
        private FloydGraph graph;
        private ushort[] idToindex;
        private uint[,] linkId;
        
        public Path(List<LinkData> _Link, List<NodeData> _Node)
        {                      
            UInt16 size = (ushort)_Node.Count;
            float[,] matrix = new float[size, size];
            linkId = new uint[size, size];
            idToindex = new ushort[_Node[_Node.Count - 1].Id + 1];

            for ( UInt16 i = 0; i < size; i++ )
            {
                for ( UInt16 j = 0; j < size; j++ )
                {
                    matrix[i, j] = float.MaxValue;
                    linkId[i, j] = uint.MaxValue;
                }
            }

            for (ushort i = 0; i < idToindex.Length; i++)
            {
                idToindex[i] = ushort.MaxValue;
            }

            foreach (NodeData n in _Node)
            {
                idToindex[n.Id] = n.ListIndex;
            }

            foreach ( LinkData l in _Link )
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
            List<NodeData> node = new List<NodeData>();
            List<LinkData> link = new List<LinkData>();

            //NetworkTopologyParking.CreateNetworkTopology(network, node, link);

            Path p = new Path(link, node);
            List<ushort> _nodesIndex = new List<ushort>();
            float _dis = 0;
            List<ushort> _pathNodes = new List<ushort>();
            List<uint> _pathLinks = new List<uint>();
            List<MovementDirectionCode> TurningMovementList = new List<MovementDirectionCode>();

            p.PathGeneration(_Origin, _Destination, 1, ref _nodesIndex, ref _pathLinks, ref _dis);
            foreach (ushort index_i in _nodesIndex)
            {
                _pathNodes.Add(node[index_i].Id);
            }

            for (int i = 1; i < _pathLinks.Count; i++)
            {
                if (link[i - 1].DownstreamLinkIds[0] == link[i].Id)
                    TurningMovementList.Add(MovementDirectionCode.Left);
                else
                    if (link[i - 1].DownstreamLinkIds[1] == link[i].Id)
                    TurningMovementList.Add(MovementDirectionCode.Through);
                else
                    TurningMovementList.Add(MovementDirectionCode.Right);
            }

            return TurningMovementList;
        }

    }
}
