namespace BigFile.WindowsForm
{
    partial class BigFileForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxDirectory = new System.Windows.Forms.TextBox();
            this.TextBoxNeedSearchExtensions = new System.Windows.Forms.TextBox();
            this.ButtonDirectory = new System.Windows.Forms.Button();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.TextBoxMaxFileSizeMb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.ButtonResult = new System.Windows.Forms.Button();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Name Filter";
            // 
            // TextBoxDirectory
            // 
            this.TextBoxDirectory.Location = new System.Drawing.Point(191, 91);
            this.TextBoxDirectory.Name = "TextBoxDirectory";
            this.TextBoxDirectory.Size = new System.Drawing.Size(410, 20);
            this.TextBoxDirectory.TabIndex = 2;
            this.TextBoxDirectory.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxDirectory_Validating);
            // 
            // TextBoxNeedSearchExtensions
            // 
            this.TextBoxNeedSearchExtensions.Location = new System.Drawing.Point(191, 142);
            this.TextBoxNeedSearchExtensions.Name = "TextBoxNeedSearchExtensions";
            this.TextBoxNeedSearchExtensions.Size = new System.Drawing.Size(410, 20);
            this.TextBoxNeedSearchExtensions.TabIndex = 3;
            this.TextBoxNeedSearchExtensions.Text = "*";
            this.TextBoxNeedSearchExtensions.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxNeedSearchExtensions_Validating);
            // 
            // ButtonDirectory
            // 
            this.ButtonDirectory.Location = new System.Drawing.Point(655, 88);
            this.ButtonDirectory.Name = "ButtonDirectory";
            this.ButtonDirectory.Size = new System.Drawing.Size(75, 23);
            this.ButtonDirectory.TabIndex = 4;
            this.ButtonDirectory.Text = "Choose Folder";
            this.ButtonDirectory.UseVisualStyleBackColor = true;
            this.ButtonDirectory.Click += new System.EventHandler(this.ButtonDirectory_Click);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(158, 263);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 5;
            this.ButtonSearch.Text = "Find";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // TextBoxMaxFileSizeMb
            // 
            this.TextBoxMaxFileSizeMb.Location = new System.Drawing.Point(268, 193);
            this.TextBoxMaxFileSizeMb.Name = "TextBoxMaxFileSizeMb";
            this.TextBoxMaxFileSizeMb.Size = new System.Drawing.Size(333, 20);
            this.TextBoxMaxFileSizeMb.TabIndex = 6;
            this.TextBoxMaxFileSizeMb.Text = "30";
            this.TextBoxMaxFileSizeMb.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxMaxFileSizeMb_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File Size (Greater than, unit Mb)";
            // 
            // ButtonStop
            // 
            this.ButtonStop.Location = new System.Drawing.Point(281, 263);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(75, 23);
            this.ButtonStop.TabIndex = 8;
            this.ButtonStop.Text = "Pause";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // ButtonResult
            // 
            this.ButtonResult.Location = new System.Drawing.Point(409, 263);
            this.ButtonResult.Name = "ButtonResult";
            this.ButtonResult.Size = new System.Drawing.Size(75, 23);
            this.ButtonResult.TabIndex = 9;
            this.ButtonResult.Text = "Result";
            this.ButtonResult.UseVisualStyleBackColor = true;
            this.ButtonResult.Click += new System.EventHandler(this.ButtonResult_Click);
            // 
            // LabelInfo
            // 
            this.LabelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInfo.ForeColor = System.Drawing.Color.Lime;
            this.LabelInfo.Location = new System.Drawing.Point(102, 311);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(591, 53);
            this.LabelInfo.TabIndex = 11;
            this.LabelInfo.Text = "Searching...";
            this.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelInfo.Visible = false;
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(539, 263);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(98, 23);
            this.ButtonClear.TabIndex = 12;
            this.ButtonClear.Text = "Clear Last Time";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // BigFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.LabelInfo);
            this.Controls.Add(this.ButtonResult);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxMaxFileSizeMb);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.ButtonDirectory);
            this.Controls.Add(this.TextBoxNeedSearchExtensions);
            this.Controls.Add(this.TextBoxDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BigFileForm";
            this.Text = "Big File";
            this.Load += new System.EventHandler(this.BigFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxDirectory;
        private System.Windows.Forms.TextBox TextBoxNeedSearchExtensions;
        private System.Windows.Forms.Button ButtonDirectory;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.TextBox TextBoxMaxFileSizeMb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.Button ButtonResult;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.Button ButtonClear;
    }
}

