using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFile.WindowsForm
{
    public class MessageView : DataAccess.Message
    {
        public bool Checked { get; set; }

        public MessageView()
        {
        }

        public MessageView(DataAccess.Message message)
        {
            this.Checked = false;
            this.ExceptionLog = message.ExceptionLog;
            this.ExceptionMessage = message.ExceptionMessage;
            this.FilePath = message.FilePath;
            this.FolderPath = message.FolderPath;
            this.Id = message.Id;
            this.MessageType = message.MessageType;
        }

        public DataAccess.Message ToMessage()
        {
            return new DataAccess.Message() { ExceptionLog = this.ExceptionLog, MessageType = this.MessageType, Id = this.Id, ExceptionMessage = this.ExceptionMessage, FilePath = this.FilePath, FolderPath = this.FolderPath };
        }
    }
}