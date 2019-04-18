using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwashSim_RouteAssign
{
    public partial class UserEquilibriumResults : Form
    {
        List<XXE_DataStructures.PathData> PathFlowResults;
        public UserEquilibriumResults(List<XXE_DataStructures.PathData> PathFlowResultsImport)
        {
            InitializeComponent();
            PathFlowResults = PathFlowResultsImport;
            DisplayDataGridView();
        }

        private void DisplayDataGridView()
        {
            dgvPathFlowResults.Rows.Clear();
            int numRows = PathFlowResults.Count;
            if (numRows > 0)
            {
                dgvPathFlowResults.Rows.Add(numRows);
                for (int row = 0; row < numRows; row++)
                {
                    dgvPathFlowResults.Rows[row].Cells[colOrigin.Name].Value = PathFlowResults[row].OrigZone;
                    dgvPathFlowResults.Rows[row].Cells[colDestination.Name].Value = PathFlowResults[row].DestZone;
                    dgvPathFlowResults.Rows[row].Cells[colPathFlow.Name].Value = PathFlowResults[row].Volume;
                }
            }
            
        }

    }
}
