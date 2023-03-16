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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsLibraryData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadExcelFile
            // 
            this.btnLoadExcelFile.Location = new System.Drawing.Point(692, 34);
            this.btnLoadExcelFile.Name = "btnLoadExcelFile";
            this.btnLoadExcelFile.Size = new System.Drawing.Size(103, 23);
            this.btnLoadExcelFile.TabIndex = 0;
            this.btnLoadExcelFile.Text = "Wczytaj";
            this.btnLoadExcelFile.UseVisualStyleBackColor = true;
            this.btnLoadExcelFile.Click += new System.EventHandler(this.btnLoadExcelFile_Click);
            // 
            // bBrowseExcelFiles
            // 
            this.bBrowseExcelFiles.Location = new System.Drawing.Point(23, 34);
            this.bBrowseExcelFiles.Name = "bBrowseExcelFiles";
            this.bBrowseExcelFiles.Size = new System.Drawing.Size(92, 23);
            this.bBrowseExcelFiles.TabIndex = 1;
            this.bBrowseExcelFiles.Text = "Wyszukaj";
            this.bBrowseExcelFiles.UseVisualStyleBackColor = true;
            this.bBrowseExcelFiles.Click += new System.EventHandler(this.bBrowseExcelFiles_Click);
            // 
            // dgvExcelData
            // 
            this.dgvExcelData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExcelData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExcelData.BackgroundColor = System.Drawing.Color.White;
            this.dgvExcelData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcelData.Location = new System.Drawing.Point(3, 167);
            this.dgvExcelData.Name = "dgvExcelData";
            this.dgvExcelData.RowHeadersVisible = false;
            this.dgvExcelData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExcelData.Size = new System.Drawing.Size(353, 330);
            this.dgvExcelData.TabIndex = 3;
            // 
            // tbSelectedExcelPath
            // 
            this.tbSelectedExcelPath.Location = new System.Drawing.Point(142, 37);
            this.tbSelectedExcelPath.Name = "tbSelectedExcelPath";
            this.tbSelectedExcelPath.Size = new System.Drawing.Size(389, 20);
            this.tbSelectedExcelPath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ścieżka pliku ";
            // 
            // cbEcelListSheets
            // 
            this.cbEcelListSheets.FormattingEnabled = true;
            this.cbEcelListSheets.Location = new System.Drawing.Point(556, 37);
            this.cbEcelListSheets.Name = "cbEcelListSheets";
            this.cbEcelListSheets.Size = new System.Drawing.Size(106, 21);
            this.cbEcelListSheets.TabIndex = 6;
            this.cbEcelListSheets.SelectedIndexChanged += new System.EventHandler(this.cbEcelListSheets_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(553, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Wskaż arkusz";
            // 
            // bBrowsePartsLibrary
            // 
            this.bBrowsePartsLibrary.Location = new System.Drawing.Point(23, 42);
            this.bBrowsePartsLibrary.Name = "bBrowsePartsLibrary";
            this.bBrowsePartsLibrary.Size = new System.Drawing.Size(91, 23);
            this.bBrowsePartsLibrary.TabIndex = 8;
            this.bBrowsePartsLibrary.Text = "Wyszukaj";
            this.bBrowsePartsLibrary.UseVisualStyleBackColor = true;
            this.bBrowsePartsLibrary.Click += new System.EventHandler(this.bBrowsePartsLibrary_Click);
            // 
            // bCompareParts
            // 
            this.bCompareParts.Location = new System.Drawing.Point(704, 102);
            this.bCompareParts.Name = "bCompareParts";
            this.bCompareParts.Size = new System.Drawing.Size(103, 46);
            this.bCompareParts.TabIndex = 9;
            this.bCompareParts.Text = "Znajdź części";
            this.bCompareParts.UseVisualStyleBackColor = true;
            this.bCompareParts.Click += new System.EventHandler(this.bCompareParts_Click);
            // 
            // bLoadParts
            // 
            this.bLoadParts.Location = new System.Drawing.Point(556, 42);
            this.bLoadParts.Name = "bLoadParts";
            this.bLoadParts.Size = new System.Drawing.Size(103, 23);
            this.bLoadParts.TabIndex = 10;
            this.bLoadParts.Text = "Wczytaj";
            this.bLoadParts.UseVisualStyleBackColor = true;
            this.bLoadParts.Click += new System.EventHandler(this.bLoadParts_Click);
            // 
            // tbSelectedPartsLibraryPath
            // 
            this.tbSelectedPartsLibraryPath.Location = new System.Drawing.Point(142, 42);
            this.tbSelectedPartsLibraryPath.Name = "tbSelectedPartsLibraryPath";
            this.tbSelectedPartsLibraryPath.Size = new System.Drawing.Size(389, 20);
            this.tbSelectedPartsLibraryPath.TabIndex = 11;
            // 
            // dgvPartsLibraryData
            // 
            this.dgvPartsLibraryData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartsLibraryData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartsLibraryData.BackgroundColor = System.Drawing.Color.White;
            this.dgvPartsLibraryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartsLibraryData.Location = new System.Drawing.Point(362, 167);
            this.dgvPartsLibraryData.Name = "dgvPartsLibraryData";
            this.dgvPartsLibraryData.RowHeadersVisible = false;
            this.dgvPartsLibraryData.Size = new System.Drawing.Size(467, 330);
            this.dgvPartsLibraryData.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bBrowseExcelFiles);
            this.groupBox1.Controls.Add(this.tbSelectedExcelPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbEcelListSheets);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnLoadExcelFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 68);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.bBrowsePartsLibrary);
            this.groupBox2.Controls.Add(this.tbSelectedPartsLibraryPath);
            this.groupBox2.Controls.Add(this.bLoadParts);
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 75);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Baza części";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ścieżka katalogu";
            // 
            // AddExcelData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(831, 499);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPartsLibraryData);
            this.Controls.Add(this.bCompareParts);
            this.Controls.Add(this.dgvExcelData);
            this.MaximumSize = new System.Drawing.Size(847, 538);
            this.MinimumSize = new System.Drawing.Size(836, 489);
            this.Name = "AddExcelData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wprowadź dane początkowe";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsLibraryData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
    }
}