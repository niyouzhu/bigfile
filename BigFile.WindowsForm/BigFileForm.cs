using BigFile.DataAccess;
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
            this.AutoValidate = AutoValidate.Disable;
            _fillLabelInfo = (str) => SetLabelInfo(str, Color.Red, 16);
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

        private ErrorProvider ErrorProvider { get; set; } = new ErrorProvider();

        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() && !HasError())
            {
                SetLabelInfo("Searching...", Color.Green);

                _bigFileFinder = new BigFileFinder(Directory, new FilterOptions() { AllowedFileSizeMb = MaxFileSizeMb, NeedSearchFileExtensionNames = Extensions.Split(new[] { ",", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries) });
                _bigFileFinder.Matched += (o) =>
                {
                    FileInfo fileInfo;
                    if (o.TryDequeue(out fileInfo))
                    {
                        DataAccessHelper.Add(new DataAccess.BigFile() { Length = fileInfo.Length, CreationTime = fileInfo.CreationTime, FileName = fileInfo.Name, FilePath = fileInfo.FullName, LastWriteTime = fileInfo.LastWriteTime });
                    }
                };
                _bigFileFinder.NewMessageArrived += (o) =>
                {
                    Library.Message message;
                    if (o.TryDequeue(out message))
                    {
                        DataAccessHelper.Add(new DataAccess.Message() { FolderPath = message.FolderPath, FilePath = message.FilePath, ExceptionMessage = message.Exception.Message, ExceptionLog = message.Exception.ToString(), MessageType = MessageType.Finder });
                    }
                };
                await _bigFileFinder.Scan().ContinueWith(task =>

                {
                    if (task.Result)
                    {
                        LabelInfo.Invoke(_fillLabelInfo, "Done! Click 'Result' button to show.");
                    }
                });
            }
            else
            {
                ShowValidationEror();
            }
        }

        private Action<string> _fillLabelInfo;

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            _bigFileFinder.Stop = _stop;
            if (_stop)
            {
                _stop = false;
                ButtonStop.Text = "Continue";
                SetLabelInfo("Stopped.", Color.Red);
            }
            else
            {
                _stop = true;
                ButtonStop.Text = "Stop";
                SetLabelInfo("Searching...", Color.Green);
            }
        }

        private bool _stop = true;

        private void ButtonResult_Click(object sender, EventArgs e)
        {
            var form = new ResultForm();
            form.Show();
        }

        private void SetLabelInfo(string text, Color fontColer, int fontSize = 24, bool visible = true)
        {
            LabelInfo.Visible = visible;
            LabelInfo.Text = text;
            var orgFont = LabelInfo.Font;
            LabelInfo.Font = new Font(orgFont.FontFamily, fontSize, orgFont.Style, orgFont.Unit, orgFont.GdiCharSet, orgFont.GdiVerticalFont);
            LabelInfo.ForeColor = fontColer;
        }

        private void TextBoxDirectory_Validating(object sender, CancelEventArgs e)
        {
            if (!System.IO.Directory.Exists(TextBoxDirectory.Text))
            {
                ErrorProvider.SetError(TextBoxDirectory, $"The directory {TextBoxDirectory.Text} cannot be found.");
            }
            else { ErrorProvider.SetError(TextBoxDirectory, null); }
        }

        private bool HasError()
        {
            if (!string.IsNullOrWhiteSpace(ErrorProvider.GetError(TextBoxNeedSearchExtensions))) return true;
            if (!string.IsNullOrWhiteSpace(ErrorProvider.GetError(TextBoxDirectory))) return true;
            if (!string.IsNullOrWhiteSpace(ErrorProvider.GetError(TextBoxMaxFileSizeMb))) return true;
            return false;
        }

        private void TextBoxNeedSearchExtensions_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxNeedSearchExtensions.Text))
            {
                ErrorProvider.SetError(TextBoxNeedSearchExtensions, $"The File Name Filter cannot be empty.");
            }
            else
            {
                ErrorProvider.SetError(TextBoxNeedSearchExtensions, null);
            }
        }

        private void TextBoxMaxFileSizeMb_Validating(object sender, CancelEventArgs e)
        {
            int fileSize;

            if (string.IsNullOrWhiteSpace(TextBoxMaxFileSizeMb.Text))
            {
                ErrorProvider.SetError(TextBoxMaxFileSizeMb, $"The File Size cannot be empty.");
            }
            else if (!int.TryParse(TextBoxMaxFileSizeMb.Text, out fileSize))
            {
                ErrorProvider.SetError(TextBoxMaxFileSizeMb, $"The File Size must be numeric.");
            }
            else
            {
                ErrorProvider.SetError(TextBoxMaxFileSizeMb, null);
            }
        }

        private void BigFileForm_Load(object sender, EventArgs e)
        {
        }

        private void ShowValidationEror()
        {
            if (!string.IsNullOrWhiteSpace(ErrorProvider.GetError(TextBoxNeedSearchExtensions))) { SetLabelInfo(ErrorProvider.GetError(TextBoxNeedSearchExtensions), Color.Red); return; }
            if (!string.IsNullOrWhiteSpace(ErrorProvider.GetError(TextBoxDirectory))) { SetLabelInfo(ErrorProvider.GetError(TextBoxDirectory), Color.Red); return; }
            if (!string.IsNullOrWhiteSpace(ErrorProvider.GetError(TextBoxMaxFileSizeMb))) { SetLabelInfo(ErrorProvider.GetError(TextBoxMaxFileSizeMb), Color.Red); return; }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you make sure?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataAccessHelper.Clear();
            }
        }

        private void ButtonMessage_Click(object sender, EventArgs e)
        {
            new MessageForm(MessageType.Finder).Show();
        }
    }
}