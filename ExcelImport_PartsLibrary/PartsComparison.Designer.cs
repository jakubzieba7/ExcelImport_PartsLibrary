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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsComparison)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPartsComparison
            // 
            this.dgvPartsComparison.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartsComparison.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartsComparison.BackgroundColor = System.Drawing.Color.White;
            this.dgvPartsComparison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartsComparison.Location = new System.Drawing.Point(5, 74);
            this.dgvPartsComparison.Name = "dgvPartsComparison";
            this.dgvPartsComparison.RowHeadersVisible = false;
            this.dgvPartsComparison.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartsComparison.Size = new System.Drawing.Size(640, 374);
            this.dgvPartsComparison.TabIndex = 0;
            this.dgvPartsComparison.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPartsComparison_DataBindingComplete);
            // 
            // bLoadPartsToSN
            // 
            this.bLoadPartsToSN.Location = new System.Drawing.Point(21, 12);
            this.bLoadPartsToSN.Name = "bLoadPartsToSN";
            this.bLoadPartsToSN.Size = new System.Drawing.Size(90, 23);
            this.bLoadPartsToSN.TabIndex = 1;
            this.bLoadPartsToSN.Text = "Załaduj do SN";
            this.bLoadPartsToSN.UseVisualStyleBackColor = true;
            this.bLoadPartsToSN.Click += new System.EventHandler(this.bLoadPartsToSN_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(21, 54);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(593, 10);
            this.progressBar1.TabIndex = 4;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(155, 12);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(90, 23);
            this.btnDeleteRow.TabIndex = 5;
            this.btnDeleteRow.Text = "Usuń część";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // PartsComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(647, 450);
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bLoadPartsToSN);
            this.Controls.Add(this.dgvPartsComparison);
            this.MaximumSize = new System.Drawing.Size(663, 489);
            this.MinimumSize = new System.Drawing.Size(663, 489);
            this.Name = "PartsComparison";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista części do importu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsComparison)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPartsComparison;
        private System.Windows.Forms.Button bLoadPartsToSN;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnDeleteRow;
    }
}