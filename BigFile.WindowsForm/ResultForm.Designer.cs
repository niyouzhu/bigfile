namespace BigFile.WindowsForm
{
    partial class ResultForm
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
            this.DataGridViewResult = new System.Windows.Forms.DataGridView();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastWriteTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.ButtonDeletion = new System.Windows.Forms.Button();
            this.CheckBoxAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.ButtonMessagesForSearch = new System.Windows.Forms.Button();
            this.ButtonMessagesForDeletion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewResult
            // 
            this.DataGridViewResult.AllowUserToAddRows = false;
            this.DataGridViewResult.AllowUserToDeleteRows = false;
            this.DataGridViewResult.AllowUserToOrderColumns = true;
            this.DataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked,
            this.Length,
            this.FileName,
            this.FilePath,
            this.LastWriteTime,
            this.CreationTime});
            this.DataGridViewResult.Location = new System.Drawing.Point(21, 12);
            this.DataGridViewResult.Name = "DataGridViewResult";
            this.DataGridViewResult.Size = new System.Drawing.Size(747, 410);
            this.DataGridViewResult.TabIndex = 0;
            this.DataGridViewResult.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridViewResult_RowsAdded);
            this.DataGridViewResult.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataGridViewResult_RowsRemoved);
            // 
            // Checked
            // 
            this.Checked.DataPropertyName = "Checked";
            this.Checked.Frozen = true;
            this.Checked.HeaderText = "Checked";
            this.Checked.Name = "Checked";
            this.Checked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Length
            // 
            this.Length.DataPropertyName = "Length";
            this.Length.Frozen = true;
            this.Length.HeaderText = "Length(Mb)";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 73;
            // 
            // FilePath
            // 
            this.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "File Path";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Width = 68;
            // 
            // LastWriteTime
            // 
            this.LastWriteTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LastWriteTime.DataPropertyName = "LastWriteTime";
            this.LastWriteTime.HeaderText = "Last Write Time";
            this.LastWriteTime.Name = "LastWriteTime";
            this.LastWriteTime.ReadOnly = true;
            this.LastWriteTime.Width = 97;
            // 
            // CreationTime
            // 
            this.CreationTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CreationTime.DataPropertyName = "CreationTime";
            this.CreationTime.HeaderText = "Creation Time";
            this.CreationTime.Name = "CreationTime";
            this.CreationTime.ReadOnly = true;
            this.CreationTime.Width = 89;
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.Location = new System.Drawing.Point(205, 438);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(75, 23);
            this.ButtonRefresh.TabIndex = 1;
            this.ButtonRefresh.Text = "Refresh";
            this.ButtonRefresh.UseVisualStyleBackColor = true;
            this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // ButtonDeletion
            // 
            this.ButtonDeletion.Location = new System.Drawing.Point(306, 438);
            this.ButtonDeletion.Name = "ButtonDeletion";
            this.ButtonDeletion.Size = new System.Drawing.Size(121, 23);
            this.ButtonDeletion.TabIndex = 2;
            this.ButtonDeletion.Text = "Delete Selected Files";
            this.ButtonDeletion.UseVisualStyleBackColor = true;
            this.ButtonDeletion.Click += new System.EventHandler(this.ButtonDeletion_Click);
            // 
            // CheckBoxAll
            // 
            this.CheckBoxAll.AutoSize = true;
            this.CheckBoxAll.Location = new System.Drawing.Point(21, 438);
            this.CheckBoxAll.Name = "CheckBoxAll";
            this.CheckBoxAll.Size = new System.Drawing.Size(70, 17);
            this.CheckBoxAll.TabIndex = 3;
            this.CheckBoxAll.Text = "Select All";
            this.CheckBoxAll.UseVisualStyleBackColor = true;
            this.CheckBoxAll.CheckedChanged += new System.EventHandler(this.CheckBoxAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total";
            // 
            // LabelTotal
            // 
            this.LabelTotal.AutoSize = true;
            this.LabelTotal.Location = new System.Drawing.Point(145, 438);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(13, 13);
            this.LabelTotal.TabIndex = 5;
            this.LabelTotal.Text = "0";
            // 
            // ButtonMessagesForSearch
            // 
            this.ButtonMessagesForSearch.Location = new System.Drawing.Point(456, 438);
            this.ButtonMessagesForSearch.Name = "ButtonMessagesForSearch";
            this.ButtonMessagesForSearch.Size = new System.Drawing.Size(133, 23);
            this.ButtonMessagesForSearch.TabIndex = 6;
            this.ButtonMessagesForSearch.Text = "Messages For Search";
            this.ButtonMessagesForSearch.UseVisualStyleBackColor = true;
            this.ButtonMessagesForSearch.Click += new System.EventHandler(this.ButtonMessagesForSearch_Click);
            // 
            // ButtonMessagesForDeletion
            // 
            this.ButtonMessagesForDeletion.Location = new System.Drawing.Point(612, 438);
            this.ButtonMessagesForDeletion.Name = "ButtonMessagesForDeletion";
            this.ButtonMessagesForDeletion.Size = new System.Drawing.Size(133, 23);
            this.ButtonMessagesForDeletion.TabIndex = 7;
            this.ButtonMessagesForDeletion.Text = "Messages For Deletion";
            this.ButtonMessagesForDeletion.UseVisualStyleBackColor = true;
            this.ButtonMessagesForDeletion.Click += new System.EventHandler(this.ButtonMessagesForDeletion_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.ButtonMessagesForDeletion);
            this.Controls.Add(this.ButtonMessagesForSearch);
            this.Controls.Add(this.LabelTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckBoxAll);
            this.Controls.Add(this.ButtonDeletion);
            this.Controls.Add(this.ButtonRefresh);
            this.Controls.Add(this.DataGridViewResult);
            this.Name = "ResultForm";
            this.Text = "Result";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.SizeChanged += new System.EventHandler(this.ResultForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewResult;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.Button ButtonDeletion;
        private System.Windows.Forms.CheckBox CheckBoxAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastWriteTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelTotal;
        private System.Windows.Forms.Button ButtonMessagesForSearch;
        private System.Windows.Forms.Button ButtonMessagesForDeletion;
    }
}