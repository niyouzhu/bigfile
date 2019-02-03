using BigFile.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigFile.WindowsForm
{
    public partial class BigFileForm : Form
    {
        public BigFileForm()
        {
            InitializeComponent();
        }

        public string Directory { get { return TextBoxDirectory.Text.Trim(); } set { TextBoxDirectory.Text = value; } }

        public string Extensions { get { return TextBoxNeedSearchExtensions.Text.Trim(); } set { TextBoxNeedSearchExtensions.Text = value; } }

        public int MaxFileSizeMb
        {
            get { return Convert.ToInt32(TextBoxMaxFileSizeMb.Text.Trim()); }
            set { TextBoxMaxFileSizeMb.Text = value.ToString(); }
        }

        private void ButtonDirectory_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Directory = dialog.SelectedPath;
                }
            }
        }

        private BigFileFinder _bigFileFinder;

        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            using (var bigFileWriter = new StreamWriter(Path.Combine(Application.StartupPath, "bigfile.txt")))
            {
                using (TextWriter exceptionWriter = new StreamWriter(Path.Combine(Application.StartupPath, "exception.txt")))
                {
                    _bigFileFinder = new BigFileFinder(Directory, new FilterOptions() { AllowedFileSizeMb = MaxFileSizeMb, NeedSearchFileExtensionNames = Extensions.Split(new[] { ",", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries) });
                    _bigFileFinder.Matched += (o) =>
                   {
                       FileInfo fileInfo;
                       if (o.TryDequeue(out fileInfo))
                       {
                           bigFileWriter.WriteLineAsync($"{fileInfo.FullName} {fileInfo.Length / 1024.0 / 1024.0}");
                       }
                   };
                    _bigFileFinder.NewMessageArrived += (o) =>
                   {
                       Library.Message message;
                       if (o.TryDequeue(out message))
                       {
                           exceptionWriter.WriteLineAsync($"{message.FilePath} {message.Exception.Message}");
                       }
                   };
                    await _bigFileFinder.Scan().ContinueWith(task =>

                    {
                        if (task.Result)
                        {
                            MessageBox.Show("Completed!");
                        }
                    });
                }
            }
        }
    }
}