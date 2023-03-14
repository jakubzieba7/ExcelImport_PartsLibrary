namespace SNPlugin
{
    partial class PartsComparison
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
            this.dgvPartsComparison = new System.Windows.Forms.DataGridView();
            this.bLoadPartsToSN = new System.Windows.Forms.Button();
            this.bRefreshPartsList = new System.Windows.Forms.Button();
            this.bDeletePart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsComparison)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPartsComparison
            // 
            this.dgvPartsComparison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartsComparison.Location = new System.Drawing.Point(-1, 94);
            this.dgvPartsComparison.Name = "dgvPartsComparison";
            this.dgvPartsComparison.Size = new System.Drawing.Size(508, 354);
            this.dgvPartsComparison.TabIndex = 0;
            this.dgvPartsComparison.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPartsComparison_DataBindingComplete);
            // 
            // bLoadPartsToSN
            // 
            this.bLoadPartsToSN.Location = new System.Drawing.Point(352, 34);
            this.bLoadPartsToSN.Name = "bLoadPartsToSN";
            this.bLoadPartsToSN.Size = new System.Drawing.Size(90, 23);
            this.bLoadPartsToSN.TabIndex = 1;
            this.bLoadPartsToSN.Text = "Załaduj do SN";
            this.bLoadPartsToSN.UseVisualStyleBackColor = true;
            this.bLoadPartsToSN.Click += new System.EventHandler(this.bLoadPartsToSN_Click);
            // 
            // bRefreshPartsList
            // 
            this.bRefreshPartsList.Location = new System.Drawing.Point(198, 34);
            this.bRefreshPartsList.Name = "bRefreshPartsList";
            this.bRefreshPartsList.Size = new System.Drawing.Size(75, 23);
            this.bRefreshPartsList.TabIndex = 2;
            this.bRefreshPartsList.Text = "Odśwież";
            this.bRefreshPartsList.UseVisualStyleBackColor = true;
            this.bRefreshPartsList.Click += new System.EventHandler(this.bRefreshPartsList_Click);
            // 
            // bDeletePart
            // 
            this.bDeletePart.Location = new System.Drawing.Point(39, 34);
            this.bDeletePart.Name = "bDeletePart";
            this.bDeletePart.Size = new System.Drawing.Size(75, 23);
            this.bDeletePart.TabIndex = 3;
            this.bDeletePart.Text = "Usuń";
            this.bDeletePart.UseVisualStyleBackColor = true;
            this.bDeletePart.Click += new System.EventHandler(this.bDeletePart_Click);
            // 
            // PartsComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 450);
            this.Controls.Add(this.bDeletePart);
            this.Controls.Add(this.bRefreshPartsList);
            this.Controls.Add(this.bLoadPartsToSN);
            this.Controls.Add(this.dgvPartsComparison);
            this.Name = "PartsComparison";
            this.Text = "PartComparison";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsComparison)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPartsComparison;
        private System.Windows.Forms.Button bLoadPartsToSN;
        private System.Windows.Forms.Button bRefreshPartsList;
        private System.Windows.Forms.Button bDeletePart;
    }
}