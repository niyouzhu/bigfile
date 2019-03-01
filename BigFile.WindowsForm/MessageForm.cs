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
    public partial class MessageForm : Form
    {
        public MessageForm(MessageType? messageType)
        {
            InitializeComponent();
            MessageType = messageType;
        }

        public MessageType? MessageType { get; set; }

        public SortableBindingList<MessageView> ResultDataSource
        {
            get { return (SortableBindingList<MessageView>)DataGridViewResult.DataSource; }
            set { DataGridViewResult.DataSource = value; }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            var result = DataAccessHelper.Search(null, null, MessageType, 0, int.MaxValue);
            var list = new SortableBindingList<MessageView>();
            foreach (var item in result)
            {
                list.Add(new MessageView(item));
            }
            ResultDataSource = list;
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
            foreach (var item in ResultDataSource)
            {
                item.Checked = CheckBoxAll.Checked;
            }
            DataGridViewResult.Refresh();
        }

        private void ButtonDeletion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you make sure?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var selected = ResultDataSource.Where(it => it.Checked);
                DataAccessHelper.Delete(selected);
                for (int i = 0; i < selected.Count(); i++)
                {
                    ResultDataSource.Remove(selected.ElementAt(i));
                }
                DataGridViewResult.Refresh();
            }
        }

        private void DataGridViewResult_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LabelTotal.Text = ResultDataSource.Count.ToString();
        }

        private void DataGridViewResult_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LabelTotal.Text = ResultDataSource.Count.ToString();
        }
    }
}