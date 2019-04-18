namespace SwashSim_RouteAssign
{
    partial class UserEquilibriumResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPathFlowResults = new System.Windows.Forms.DataGridView();
            this.colOrigin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPathNodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPathFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPathFlowResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPathFlowResults
            // 
            this.dgvPathFlowResults.AllowUserToAddRows = false;
            this.dgvPathFlowResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPathFlowResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrigin,
            this.colDestination,
            this.colPathNodes,
            this.colPathFlow,
            this.colProbability});
            this.dgvPathFlowResults.Location = new System.Drawing.Point(21, 12);
            this.dgvPathFlowResults.Name = "dgvPathFlowResults";
            this.dgvPathFlowResults.RowTemplate.Height = 24;
            this.dgvPathFlowResults.Size = new System.Drawing.Size(667, 461);
            this.dgvPathFlowResults.TabIndex = 0;
            // 
            // colOrigin
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colOrigin.DefaultCellStyle = dataGridViewCellStyle1;
            this.colOrigin.HeaderText = "Origin";
            this.colOrigin.Name = "colOrigin";
            this.colOrigin.ReadOnly = true;
            // 
            // colDestination
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDestination.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDestination.HeaderText = "Destination";
            this.colDestination.Name = "colDestination";
            this.colDestination.ReadOnly = true;
            // 
            // colPathNodes
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPathNodes.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPathNodes.HeaderText = "Path (Nodes)";
            this.colPathNodes.Name = "colPathNodes";
            this.colPathNodes.ReadOnly = true;
            this.colPathNodes.Width = 120;
            // 
            // colPathFlow
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPathFlow.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPathFlow.HeaderText = "Volume";
            this.colPathFlow.Name = "colPathFlow";
            this.colPathFlow.ReadOnly = true;
            // 
            // colProbability
            // 
            this.colProbability.HeaderText = "Probability";
            this.colProbability.Name = "colProbability";
            this.colProbability.ReadOnly = true;
            // 
            // UserEquilibriumResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 485);
            this.Controls.Add(this.dgvPathFlowResults);
            this.Name = "UserEquilibriumResults";
            this.Text = "UserEquilibriumResults";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPathFlowResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPathFlowResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathNodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProbability;
    }
}