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
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }

        public SortableBindingList<BigFileView> ResultDataSource
        {
            get { return (SortableBindingList<BigFileView>)DataGridViewResult.DataSource; }
            set { DataGridViewResult.DataSource = value; }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            var result = DataAccessHelper.Search(null, 0, 0, int.MaxValue);
            ResultDataSource = result.ForEach<SortableBindingList<BigFileView>, DataAccess.BigFile, BigFileView>(it => new BigFileView(it));
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            DataGridViewResult.AutoGenerateColumns = false;
            DataGridViewResult.ColumnHeaderMouseClick += (o, e2) =>
            {
                var column = DataGridViewResult.SortedColumn;
                if (column.HeaderCell.SortGlyphDirection == SortOrder.Ascending)
                {
                    column.HeaderCell.SortGlyphDirection = SortOrder.Descending;

                    DataGridViewResult.Sort(column, ListSortDirection.Ascending);
                }
                else
                {
                    column.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    DataGridViewResult.Sort(column, ListSortDirection.Descending);
                }
            };
            ButtonRefresh_Click(null, null);
        }

        private void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            ResultDataSource.ForEach(it => it.Checked = CheckBoxAll.Checked);

            DataGridViewResult.Refresh();
        }

        private void ButtonDeletion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you make sure?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var fileProcessor = new FileProcessor();
                fileProcessor.DeletionSuccess += (file) =>
                {
                    DataAccessHelper.Delete(file.FullName);
                    var selected = ResultDataSource.Where(it => it.FilePath == file.FullName);
                    for (int i = 0; i < selected.Count(); i++)
                    {
                        ResultDataSource.Remove(selected.ElementAt(i));
                    }
                };
                fileProcessor.NewMessageArrived += (o) =>
                {
                    Library.Message message;
                    if (o.TryDequeue(out message))
                    {
                        DataAccessHelper.Add(new DataAccess.Message() { FolderPath = message.FolderPath, FilePath = message.FilePath, ExceptionMessage = message.Exception.Message, ExceptionLog = message.Exception.ToString(), MessageType = MessageType.Deletion });
                    }
                };
                fileProcessor.Delete(GeneratorFileInfos(ResultDataSource.Where(it => it.Checked)));
                DataGridViewResult.Refresh();
            }
        }

        private IEnumerable<FileInfo> GeneratorFileInfos(IEnumerable<BigFileView> bigFiles)
        {
            return bigFiles.ForEach<List<FileInfo>, BigFileView, FileInfo>(it => new FileInfo(it.FilePath));
        }

        private void ButtonMessagesForSearch_Click(object sender, EventArgs e)
        {
            new MessageForm(MessageType.Finder).Show();
        }

        private void DataGridViewResult_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LabelTotal.Text = ResultDataSource.Count.ToString();
        }

        private void DataGridViewResult_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LabelTotal.Text = ResultDataSource.Count.ToString();
        }

        private void ButtonMessagesForDeletion_Click(object sender, EventArgs e)
        {
            new MessageForm(MessageType.Deletion).Show();
        }
    }
}