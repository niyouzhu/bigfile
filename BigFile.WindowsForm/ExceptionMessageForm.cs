using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigFile.WindowsForm
{
    public partial class ExceptionMessageForm : Form
    {
        public ExceptionMessageForm(Exception exception) : this()
        {
            Exception = exception;
        }

        public Exception Exception { get; set; }

        public ExceptionMessageForm()
        {
            InitializeComponent();
        }

        private void ExceptionMessageForm_Load(object sender, EventArgs e)
        {
            TextBoxMessage.Text = Format(Exception);
        }

        private string Format(string previousMessage, Exception ex)
        {
            if (ex != null)
            {
                if (string.IsNullOrWhiteSpace(previousMessage))
                {
                    previousMessage = ex.Message;
                }
                else
                    previousMessage = previousMessage + Environment.NewLine + ex.Message;
            }

            if (ex.InnerException != null)
            {
                return Format(previousMessage, ex.InnerException);
            }
            return previousMessage;
        }

        private string Format(Exception ex)
        {
            string message = null;
            return Format(message, ex);
        }
    }
}