using System.Collections.Generic;
using SwashSim_Network;



namespace SwashSim_RouteAssign
{
    public static class NetworkTopologyParking
    {
        /*  
         *                                                                   
         *701-->(19)==(1)===(2)==========================================(3)===(4)====================================(5)
         *             \\                                                 \\                                           \\
         *              \\                                                 \\                                           \\
         *              (6)                                                 (7)                                          (8)
         *              ||                                                  ||                                           ||
         *              ||                                                  ||                                           ||
         *              ||                                                  ||                                           ||
         *              ||                                                  ||                                           ||
         *              ||                                                  ||                                           ||
         *             (9)                                                 (10)                                         (11)
         *              \\                                                  //                                           //
         *               \\                                                //                                           // 
         *               (12)================(13)    (14)================(15)===(16)=================================(17)
         *                                     \\    //
         *                                      \\  //
         *                                       (18)
         *                                        ||
         *                                        ||
         *                                        801
         */



        public static void CreateNetworkTopology(NetworkData network, List<NodeData> nodes, List<LinkData> links)
        {
            network.NumLinks = 0;
            const int XcoordStart = 5;
            const int YcoordStart = 5;
            const int EntryLinkLength = 250;
            const int ExitLinkLength = 500;
            const int IntersectionX = 6;
            const int IntersectionY = 6;
            const int LongLinkLength = 1000;
            const int ShortLinkLength = LongLinkLength / 2 - 2 * IntersectionX;
            const float GradePct_Left = 0;
            const float GradePct_Right = 0;
            const float GradePct_Down = 0;
            const float GradePct_DownLeft = 0;
            const float GradePct_DownRight = 0;
            const float FlowSpeed = 51.3f;  //35 mi/h * 1.467
            List<float> EnteringPctTrucks = new List<float> { 100, 0, 0, 0, 0 };
            List<float> EnteringDriverTypePcts = new List<float> { 5, 8, 10, 12, 15, 15, 12, 10, 8, 5 };
            float[] MinEntryHeadway = new float[] { 2.0f, 2.5f, 3.0f, 3.5f };
            bool UsePctTurnsByFleet = true;
            float[] TurningPcts = new float[3];
            List<float[]> PctTurnsAtLinkEnd = new List<float[]>();


            // connector node
            network.NumNodes++;
            LinkConnectorNode NewConnectorNode = new LinkConnectorNode(1, NodeType.LinkConnector, 0, XcoordStart + EntryLinkLength, YcoordStart);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(2, NodeType.LinkConnector, 1, XcoordStart + EntryLinkLength + 2 * IntersectionX, YcoordStart);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(3, NodeType.LinkConnector, 2, XcoordStart + EntryLinkLength + 2 * IntersectionX + LongLinkLength, YcoordStart);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(4, NodeType.LinkConnector, 3, XcoordStart + EntryLinkLength + 2 * IntersectionX + LongLinkLength + 2 * IntersectionX, YcoordStart - IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(5, NodeType.LinkConnector, 4, XcoordStart + EntryLinkLength + 2 * IntersectionX + LongLinkLength + 2 * IntersectionX + LongLinkLength, YcoordStart - IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(6, NodeType.LinkConnector, 5, XcoordStart + EntryLinkLength + IntersectionX, YcoordStart + 2 * IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(7, NodeType.LinkConnector, 6, XcoordStart + EntryLinkLength + IntersectionX + LongLinkLength + 2 * IntersectionX, YcoordStart + 2 * IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(8, NodeType.LinkConnector, 7, XcoordStart + EntryLinkLength + IntersectionX + LongLinkLength + 2 * IntersectionX + LongLinkLength + 2 * IntersectionX, YcoordStart + 2 * IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(9, NodeType.LinkConnector, 8, XcoordStart + EntryLinkLength + IntersectionX, YcoordStart + 2 * IntersectionY + LongLinkLength);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(10, NodeType.LinkConnector, 9, XcoordStart + EntryLinkLength + IntersectionX + LongLinkLength + 2 * IntersectionX, YcoordStart + 2 * IntersectionY + LongLinkLength);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(11, NodeType.LinkConnector, 10, XcoordStart + EntryLinkLength + IntersectionX + LongLinkLength + 2 * IntersectionX + LongLinkLength + 2 * IntersectionX, YcoordStart + 2 * IntersectionY + LongLinkLength);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(12, NodeType.LinkConnector, 11, XcoordStart + EntryLinkLength + 2 * IntersectionX, YcoordStart + 2 * IntersectionY + LongLinkLength + IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(13, NodeType.LinkConnector, 12, XcoordStart + EntryLinkLength + 2 * IntersectionX + ShortLinkLength, YcoordStart + 2 * IntersectionY + LongLinkLength + IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(14, NodeType.LinkConnector, 13, XcoordStart + EntryLinkLength + 2 * IntersectionX + ShortLinkLength + 4 * IntersectionX, YcoordStart + 2 * IntersectionY + LongLinkLength + IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(15, NodeType.LinkConnector, 14, XcoordStart + EntryLinkLength + 2 * IntersectionX + ShortLinkLength + 4 * IntersectionX + ShortLinkLength, YcoordStart + 2 * IntersectionY + LongLinkLength + IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(16, NodeType.LinkConnector, 15, XcoordStart + EntryLinkLength + 2 * IntersectionX + ShortLinkLength + 4 * IntersectionX + ShortLinkLength + 2 * IntersectionX, YcoordStart + 2 * IntersectionY + LongLinkLength + IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(17, NodeType.LinkConnector, 16, XcoordStart + EntryLinkLength + 2 * IntersectionX + ShortLinkLength + 4 * IntersectionX + ShortLinkLength + 2 * IntersectionX + LongLinkLength, YcoordStart + 2 * IntersectionY + LongLinkLength + IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(18, NodeType.LinkConnector, 17, XcoordStart + EntryLinkLength + 2 * IntersectionX + ShortLinkLength + 2 * IntersectionX, YcoordStart + 2 * IntersectionY + LongLinkLength + IntersectionY + IntersectionY);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // connector node
            network.NumNodes++;
            NewConnectorNode = new LinkConnectorNode(19, NodeType.LinkConnector, 18, XcoordStart + EntryLinkLength/2, YcoordStart);
            nodes.Add(NewConnectorNode);
            network.NodeIdList.Add(NewConnectorNode.Id);

            // entry node
            network.NumNodes++;
            EntryNode NewEntryNode = new EntryNode(701, NodeType.Entry, 19, XcoordStart, YcoordStart, 70119, 1, MinEntryHeadway, 400, 400, EnteringPctTrucks, EnteringDriverTypePcts, false, 100, FlowSpeed);
            nodes.Add(NewEntryNode);
            network.NodeIdList.Add(NewEntryNode.Id);

            // exit node
            network.NumNodes++;
            ExitNode NewExitNode = new ExitNode(801, NodeType.Exit, 20, XcoordStart + EntryLinkLength + 2 * IntersectionX + ShortLinkLength + 2 * IntersectionX, YcoordStart + 2 * IntersectionY + LongLinkLength + IntersectionY + IntersectionY + ExitLinkLength);
            nodes.Add(NewExitNode);
            network.NodeIdList.Add(NewExitNode.Id);


            // link 1->2
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 100, 0 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }

            network.NumLinks++;
            LinkData NewLink = new LinkData(0, nodes[0], nodes[1], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Right, FlowSpeed, 2, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 191, 0, 0, 23, 0, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);
            NewLink.Lanes[1].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 1, 0);
            NewLink.Lanes[1].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 2, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);
            NewLink.Lanes[1].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 2, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 2->3
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 67, 33 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }

            network.NumLinks++;
            NewLink = new LinkData(1, nodes[1], nodes[2], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Right, FlowSpeed, 2, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 12, 0, 0, 34, 37, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Right);
            NewLink.Lanes[1].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 1, 0);
            NewLink.Lanes[1].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 2, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 0, 1);
            NewLink.Lanes[1].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            NewLink.Lanes[0].Type = LaneType.AuxFull;

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 3->4
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 100, 0 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }

            network.NumLinks++;
            NewLink = new LinkData(2, nodes[2], nodes[3], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Right, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 23, 0, 0, 45, 0, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 4->5
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 0, 100 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(3, nodes[3], nodes[4], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Right, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 34, 0, 0, 0, 58, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Right);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 0, 1);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 1->6
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 100, 0 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(4, nodes[0], nodes[5], LinkType.ArterialConnector,LinkCurveType.Bezier, GradePct_DownRight, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 0, 191, 0, 69, 0, TravelDirection.RightTurn, FreeFlowSpeedMethod.Measured, TwoLaneLinkPassingDesignation.NotAllowed, TwoLaneLinkPassingRule.None, nodes[0].PositionX, nodes[0].PositionY + 6, nodes[0].PositionX + 6, nodes[0].PositionY + 6, nodes[0].PositionX + 6, nodes[0].PositionY + 12);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 0, 1);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 3->7
            network.NumLinks++;
            NewLink = new LinkData(5, nodes[2], nodes[6], LinkType.ArterialConnector,LinkCurveType.Bezier, GradePct_DownRight, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 0, 23, 0, 710, 0, TravelDirection.RightTurn, FreeFlowSpeedMethod.Measured, TwoLaneLinkPassingDesignation.NotAllowed, TwoLaneLinkPassingRule.None, nodes[2].PositionX, nodes[2].PositionY + 6, nodes[2].PositionX + 6, nodes[2].PositionY + 6, nodes[2].PositionX + 6, nodes[2].PositionY + 12);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 0, 1);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 5->8
            network.NumLinks++;
            NewLink = new LinkData(6, nodes[4], nodes[7], LinkType.ArterialConnector,LinkCurveType.Bezier, GradePct_DownRight, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 0, 45, 0, 811, 0, TravelDirection.RightTurn, FreeFlowSpeedMethod.Measured, TwoLaneLinkPassingDesignation.NotAllowed, TwoLaneLinkPassingRule.None, nodes[4].PositionX, nodes[4].PositionY, nodes[4].PositionX + 6, nodes[4].PositionY, nodes[4].PositionX + 6, nodes[4].PositionY + 6);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 0, 1);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 6->9
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 100, 0, 0 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(7, nodes[5], nodes[8], LinkType.ArterialConnector,LinkCurveType.Linear, GradePct_Down, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 16, 0, 912, 0, 0, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Left);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(1, 0, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(1, 0, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 7->10
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 0, 100 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(8, nodes[6], nodes[9], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Down, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 37, 0, 0, 0, 1015, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Right);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(1, 0, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 0, 1);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 8->11
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 0, 100 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(9, nodes[7], nodes[10], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Down, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 58, 0, 0, 0, 1117, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Right);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(1, 0, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 0, 1);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 9->12
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 100, 0, 0 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(10, nodes[8], nodes[11], LinkType.ArterialConnector, LinkCurveType.Bezier, GradePct_DownRight, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 69, 0, 0, 0, 1213, 0, TravelDirection.LeftTurn, FreeFlowSpeedMethod.Measured, TwoLaneLinkPassingDesignation.NotAllowed, TwoLaneLinkPassingRule.None, nodes[8].PositionX, nodes[8].PositionY, nodes[8].PositionX, nodes[8].PositionY + 6, nodes[8].PositionX + 6, nodes[8].PositionY + 6);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(1, 0, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 10->15
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 100, 0 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(11, nodes[9], nodes[14], LinkType.ArterialConnector, LinkCurveType.Bezier, GradePct_DownLeft, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 0, 710, 0, 1514, 0, TravelDirection.RightTurn, FreeFlowSpeedMethod.Measured, TwoLaneLinkPassingDesignation.NotAllowed, TwoLaneLinkPassingRule.None, nodes[9].PositionX, nodes[9].PositionY, nodes[9].PositionX, nodes[9].PositionY + 6, nodes[9].PositionX - 6, nodes[9].PositionY + 6);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 0, 1);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 11->17
            network.NumLinks++;
            NewLink = new LinkData(12, nodes[10], nodes[16], LinkType.ArterialConnector, LinkCurveType.Bezier, GradePct_DownLeft, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 811, 0, 0, 0, 1716, 0, TravelDirection.RightTurn, FreeFlowSpeedMethod.Measured, TwoLaneLinkPassingDesignation.NotAllowed, TwoLaneLinkPassingRule.None, nodes[10].PositionX, nodes[10].PositionY, nodes[10].PositionX, nodes[10].PositionY + 6, nodes[10].PositionX - 6, nodes[10].PositionY + 6);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 0, 1);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 12->13
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 0, 100 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(13, nodes[11], nodes[12], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Right, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 912, 0, 0, 0, 0, 1318, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Right);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(1, 0, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 0, 1);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 15->14
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 100, 0, 0 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(14, nodes[14], nodes[13], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Left, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 1615, 1015, 1418, 0, 0, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Left);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 1, 1);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(1, 0, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 16->15
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 100, 0 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(15, nodes[15], nodes[14], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Left, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 1716, 0, 0, 1514, 0, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 17->16
            network.NumLinks++;
            NewLink = new LinkData(16, nodes[16], nodes[15], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Left, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 0, 1117, 0, 1615, 0, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 13->18
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 0, 100 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(17, nodes[12], nodes[17], LinkType.ArterialConnector, LinkCurveType.Bezier, GradePct_DownRight, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 0, 1213, 0, 18801, 0, TravelDirection.RightTurn, FreeFlowSpeedMethod.Measured, TwoLaneLinkPassingDesignation.NotAllowed, TwoLaneLinkPassingRule.None, nodes[12].PositionX, nodes[12].PositionY, nodes[12].PositionX + 6, nodes[12].PositionY, nodes[12].PositionX + 6, nodes[12].PositionY + 6);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 0, 1);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 14->18
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 100, 0, 0 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(18, nodes[13], nodes[17], LinkType.ArterialConnector, LinkCurveType.Bezier, GradePct_Left, FlowSpeed, 1, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 1514, 0, 0, 0, 18801, 0, TravelDirection.LeftTurn, FreeFlowSpeedMethod.Measured, TwoLaneLinkPassingDesignation.NotAllowed, TwoLaneLinkPassingRule.None, nodes[13].PositionX, nodes[13].PositionY, nodes[13].PositionX - 6, nodes[13].PositionY, nodes[13].PositionX - 6, nodes[13].PositionY + 6);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(1, 0, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 2, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // link 19->1
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 50, 50 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(19, nodes[18], nodes[0], LinkType.ArterialConnector, LinkCurveType.Linear, GradePct_Right, FlowSpeed, 2, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 70119, 0, 0, 12, 16, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);
            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Right);
            NewLink.Lanes[1].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 1, 0);
            NewLink.Lanes[1].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 2, 0);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 1);
            NewLink.Lanes[1].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 2, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);


            // entry link
            PctTurnsAtLinkEnd = new List<float[]>();
            for (int k = 0; k <= 4; k++)
            {
                TurningPcts = new float[] { 0, 100, 0 };
                PctTurnsAtLinkEnd.Add(TurningPcts);
            }
            network.NumLinks++;
            NewLink = new LinkData(20, nodes[19], nodes[18], LinkType.ArterialEntry, LinkCurveType.Linear, GradePct_Right, FlowSpeed, 2, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 0, 0, 0, 0, 191, 0, TravelDirection.Straight);
            
            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);
            NewLink.Lanes[1].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 1, 0);
            NewLink.Lanes[1].ConnectingLaneIdsDownstream = LaneData.SetConnectingLaneIds(0, 2, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);

            // exit link
            network.NumLinks++;
            NewLink = new LinkData(21, nodes[17], nodes[20], LinkType.ArterialExit, LinkCurveType.Linear, 0, FlowSpeed, 2, UsePctTurnsByFleet, PctTurnsAtLinkEnd, 1318, 0, 1418, 0, 0, 0, TravelDirection.Straight);

            NewLink.Lanes[0].AllowedTurnMovements.Add(MovementDirectionCode.Through);
            NewLink.Lanes[1].AllowedTurnMovements.Add(MovementDirectionCode.Through);

            NewLink.Lanes[0].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(0, 0, 1);
            NewLink.Lanes[1].ConnectingLaneIdsUpstream = LaneData.SetConnectingLaneIds(1, 0, 0);

            links.Add(NewLink);
            network.LinkIdList.Add(NewLink.Id);
        }


    }
}
