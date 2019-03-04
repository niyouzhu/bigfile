namespace BigFile.WindowsForm
{
    partial class MessageForm
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
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.ButtonDeletion = new System.Windows.Forms.Button();
            this.CheckBoxAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.FilePath});
            this.DataGridViewResult.Location = new System.Drawing.Point(21, 12);
            this.DataGridViewResult.Name = "DataGridViewResult";
            this.DataGridViewResult.Size = new System.Drawing.Size(747, 410);
            this.DataGridViewResult.TabIndex = 0;
            this.DataGridViewResult.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridViewResult_RowsAdded);
            this.DataGridViewResult.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataGridViewResult_RowsRemoved);
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.Location = new System.Drawing.Point(204, 433);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(75, 23);
            this.ButtonRefresh.TabIndex = 1;
            this.ButtonRefresh.Text = "Refresh";
            this.ButtonRefresh.UseVisualStyleBackColor = true;
            this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // ButtonDeletion
            // 
            this.ButtonDeletion.Location = new System.Drawing.Point(314, 433);
            this.ButtonDeletion.Name = "ButtonDeletion";
            this.ButtonDeletion.Size = new System.Drawing.Size(147, 23);
            this.ButtonDeletion.TabIndex = 2;
            this.ButtonDeletion.Text = "Delete Selected Messages";
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
            this.Length.DataPropertyName = "FolderPath";
            this.Length.Frozen = true;
            this.Length.HeaderText = "Directory Path";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FileName.DataPropertyName = "FilePath";
            this.FileName.HeaderText = "File Path";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 73;
            // 
            // FilePath
            // 
            this.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FilePath.DataPropertyName = "ExceptionMessage";
            this.FilePath.HeaderText = "Exception Message";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Width = 114;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.LabelTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckBoxAll);
            this.Controls.Add(this.ButtonDeletion);
            this.Controls.Add(this.ButtonRefresh);
            this.Controls.Add(this.DataGridViewResult);
            this.Name = "MessageForm";
            this.Text = "Result";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewResult;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.Button ButtonDeletion;
        private System.Windows.Forms.CheckBox CheckBoxAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
    }
}