namespace SNPlugin
{
    partial class AddExcelData
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
            this.btnLoadExcelFile = new System.Windows.Forms.Button();
            this.bBrowseExcelFiles = new System.Windows.Forms.Button();
            this.dgvExcelData = new System.Windows.Forms.DataGridView();
            this.tbSelectedExcelPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEcelListSheets = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bBrowsePartsLibrary = new System.Windows.Forms.Button();
            this.bCompareParts = new System.Windows.Forms.Button();
            this.bLoadParts = new System.Windows.Forms.Button();
            this.tbSelectedPartsLibraryPath = new System.Windows.Forms.TextBox();
            this.dgvPartsLibraryData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsLibraryData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadExcelFile
            // 
            this.btnLoadExcelFile.Location = new System.Drawing.Point(698, 24);
            this.btnLoadExcelFile.Name = "btnLoadExcelFile";
            this.btnLoadExcelFile.Size = new System.Drawing.Size(103, 23);
            this.btnLoadExcelFile.TabIndex = 0;
            this.btnLoadExcelFile.Text = "Wczytaj Excel";
            this.btnLoadExcelFile.UseVisualStyleBackColor = true;
            this.btnLoadExcelFile.Click += new System.EventHandler(this.btnLoadExcelFile_Click);
            // 
            // bBrowseExcelFiles
            // 
            this.bBrowseExcelFiles.Location = new System.Drawing.Point(12, 24);
            this.bBrowseExcelFiles.Name = "bBrowseExcelFiles";
            this.bBrowseExcelFiles.Size = new System.Drawing.Size(127, 23);
            this.bBrowseExcelFiles.TabIndex = 1;
            this.bBrowseExcelFiles.Text = "Wyszukaj Excel";
            this.bBrowseExcelFiles.UseVisualStyleBackColor = true;
            this.bBrowseExcelFiles.Click += new System.EventHandler(this.bBrowseExcelFiles_Click);
            // 
            // dgvExcelData
            // 
            this.dgvExcelData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExcelData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcelData.Location = new System.Drawing.Point(0, 97);
            this.dgvExcelData.Name = "dgvExcelData";
            this.dgvExcelData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExcelData.Size = new System.Drawing.Size(390, 353);
            this.dgvExcelData.TabIndex = 3;
            // 
            // tbSelectedExcelPath
            // 
            this.tbSelectedExcelPath.Location = new System.Drawing.Point(157, 27);
            this.tbSelectedExcelPath.Name = "tbSelectedExcelPath";
            this.tbSelectedExcelPath.Size = new System.Drawing.Size(389, 20);
            this.tbSelectedExcelPath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ścieżka pliku Excel";
            // 
            // cbEcelListSheets
            // 
            this.cbEcelListSheets.FormattingEnabled = true;
            this.cbEcelListSheets.Location = new System.Drawing.Point(572, 27);
            this.cbEcelListSheets.Name = "cbEcelListSheets";
            this.cbEcelListSheets.Size = new System.Drawing.Size(106, 21);
            this.cbEcelListSheets.TabIndex = 6;
            this.cbEcelListSheets.SelectedIndexChanged += new System.EventHandler(this.cbEcelListSheets_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(572, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Wskaż arkusz";
            // 
            // bBrowsePartsLibrary
            // 
            this.bBrowsePartsLibrary.Location = new System.Drawing.Point(13, 54);
            this.bBrowsePartsLibrary.Name = "bBrowsePartsLibrary";
            this.bBrowsePartsLibrary.Size = new System.Drawing.Size(126, 23);
            this.bBrowsePartsLibrary.TabIndex = 8;
            this.bBrowsePartsLibrary.Text = "Wyszukaj Bazę Części";
            this.bBrowsePartsLibrary.UseVisualStyleBackColor = true;
            this.bBrowsePartsLibrary.Click += new System.EventHandler(this.bBrowsePartsLibrary_Click);
            // 
            // bCompareParts
            // 
            this.bCompareParts.Location = new System.Drawing.Point(698, 53);
            this.bCompareParts.Name = "bCompareParts";
            this.bCompareParts.Size = new System.Drawing.Size(103, 23);
            this.bCompareParts.TabIndex = 9;
            this.bCompareParts.Text = "Porównaj części";
            this.bCompareParts.UseVisualStyleBackColor = true;
            this.bCompareParts.Click += new System.EventHandler(this.bCompareParts_Click);
            // 
            // bLoadParts
            // 
            this.bLoadParts.Location = new System.Drawing.Point(575, 53);
            this.bLoadParts.Name = "bLoadParts";
            this.bLoadParts.Size = new System.Drawing.Size(103, 23);
            this.bLoadParts.TabIndex = 10;
            this.bLoadParts.Text = "Wczytaj Części";
            this.bLoadParts.UseVisualStyleBackColor = true;
            this.bLoadParts.Click += new System.EventHandler(this.bLoadParts_Click);
            // 
            // tbSelectedPartsLibraryPath
            // 
            this.tbSelectedPartsLibraryPath.Location = new System.Drawing.Point(157, 56);
            this.tbSelectedPartsLibraryPath.Name = "tbSelectedPartsLibraryPath";
            this.tbSelectedPartsLibraryPath.Size = new System.Drawing.Size(389, 20);
            this.tbSelectedPartsLibraryPath.TabIndex = 11;
            // 
            // dgvPartsLibraryData
            // 
            this.dgvPartsLibraryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartsLibraryData.Location = new System.Drawing.Point(396, 97);
            this.dgvPartsLibraryData.Name = "dgvPartsLibraryData";
            this.dgvPartsLibraryData.Size = new System.Drawing.Size(424, 353);
            this.dgvPartsLibraryData.TabIndex = 12;
            // 
            // AddExcelData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.dgvPartsLibraryData);
            this.Controls.Add(this.tbSelectedPartsLibraryPath);
            this.Controls.Add(this.bLoadParts);
            this.Controls.Add(this.bCompareParts);
            this.Controls.Add(this.bBrowsePartsLibrary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEcelListSheets);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSelectedExcelPath);
            this.Controls.Add(this.dgvExcelData);
            this.Controls.Add(this.bBrowseExcelFiles);
            this.Controls.Add(this.btnLoadExcelFile);
            this.Name = "AddExcelData";
            this.Text = "AddExcelData";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsLibraryData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadExcelFile;
        private System.Windows.Forms.Button bBrowseExcelFiles;
        private System.Windows.Forms.DataGridView dgvExcelData;
        private System.Windows.Forms.TextBox tbSelectedExcelPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEcelListSheets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bBrowsePartsLibrary;
        private System.Windows.Forms.Button bCompareParts;
        private System.Windows.Forms.Button bLoadParts;
        private System.Windows.Forms.TextBox tbSelectedPartsLibraryPath;
        private System.Windows.Forms.DataGridView dgvPartsLibraryData;
    }
}