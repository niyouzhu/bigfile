using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BigFile.Library
{
    public class FileProcessor
    {
        public event Action<FileInfo> DeletionSuccess;

        public event Action<MessageQueue> NewMessageArrived;

        private bool Delete(FileInfo file, out Exception exception)
        {
            exception = null;
            if (file.Exists)
            {
                try
                {
                    File.Delete(file.FullName);
                    return true;
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }
            return false;
        }

        public void Delete(IEnumerable<FileInfo> files)
        {
            files.ForEach(Delete);
        }

        public void Delete(FileInfo file)
        {
            Exception exception;
            if (Delete(file, out exception))
            {
                DeletionSuccess?.Invoke(file);
            }
            else
            {
                Messages.Enqueue(new Message() { Exception = exception, FilePath = file.FullName, FolderPath = file.DirectoryName });
            }
        }

        private MessageQueue _messages;

        public MessageQueue Messages
        {
            get
            {
                if (_messages == null)
                {
                    _messages = new MessageQueue();
                    _messages.Enqueued += () => NewMessageArrived?.Invoke(_messages);
                }
                return _messages;
            }
        }
    }
}