using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXE_DataStructures;
namespace SwashSim_RouteAssign
{
    public class PathResults
    {
        List<PathData> PathFlowResults;
        public List<PathAssignment> ObtainPathAssignmentList(List<PathData> PathFlowResultsImport)
        {
            PathFlowResults = PathFlowResultsImport;
            List<PathAssignment> PathAssignmentList = new List<PathAssignment>();
            return PathAssignmentList;
        }

        private void CalculatePathProbability()
        {

        }
    }

    public class PathAssignment
    {
        private int _origin;
        private List<int> _nodes;
        private double _volume;
        private double _probability;

        public int Origin
        {
            get
            {
                return _origin;
            }

            set
            {
                _origin = value;
            }
        }

        public List<int> Nodes
        {
            get
            {
                return _nodes;
            }

            set
            {
                _nodes = value;
            }
        }

        public double Volume
        {
            get
            {
                return _volume;
            }

            set
            {
                _volume = value;
            }
        }

        public double Probability
        {
            get
            {
                return _probability;
            }

            set
            {
                _probability = value;
            }
        }

        public PathAssignment()
        {
            _nodes = new List<int>();

        }





    }
}
