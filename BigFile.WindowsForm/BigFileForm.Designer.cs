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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // TextBoxDirectory
            // 
            this.TextBoxDirectory.Location = new System.Drawing.Point(191, 91);
            this.TextBoxDirectory.Name = "TextBoxDirectory";
            this.TextBoxDirectory.Size = new System.Drawing.Size(390, 20);
            this.TextBoxDirectory.TabIndex = 2;
            // 
            // TextBoxNeedSearchExtensions
            // 
            this.TextBoxNeedSearchExtensions.Location = new System.Drawing.Point(191, 142);
            this.TextBoxNeedSearchExtensions.Name = "TextBoxNeedSearchExtensions";
            this.TextBoxNeedSearchExtensions.Size = new System.Drawing.Size(390, 20);
            this.TextBoxNeedSearchExtensions.TabIndex = 3;
            this.TextBoxNeedSearchExtensions.Text = "*";
            // 
            // ButtonDirectory
            // 
            this.ButtonDirectory.Location = new System.Drawing.Point(611, 89);
            this.ButtonDirectory.Name = "ButtonDirectory";
            this.ButtonDirectory.Size = new System.Drawing.Size(75, 23);
            this.ButtonDirectory.TabIndex = 4;
            this.ButtonDirectory.Text = "button1";
            this.ButtonDirectory.UseVisualStyleBackColor = true;
            this.ButtonDirectory.Click += new System.EventHandler(this.ButtonDirectory_Click);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(259, 242);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 5;
            this.ButtonSearch.Text = "button2";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // TextBoxMaxFileSizeMb
            // 
            this.TextBoxMaxFileSizeMb.Location = new System.Drawing.Point(191, 193);
            this.TextBoxMaxFileSizeMb.Name = "TextBoxMaxFileSizeMb";
            this.TextBoxMaxFileSizeMb.Size = new System.Drawing.Size(390, 20);
            this.TextBoxMaxFileSizeMb.TabIndex = 6;
            this.TextBoxMaxFileSizeMb.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // ButtonStop
            // 
            this.ButtonStop.Location = new System.Drawing.Point(379, 242);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(75, 23);
            this.ButtonStop.TabIndex = 8;
            this.ButtonStop.Text = "button2";
            this.ButtonStop.UseVisualStyleBackColor = true;
            // 
            // BigFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

