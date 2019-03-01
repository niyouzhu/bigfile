using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFile.WindowsForm
{
    public class BigFileView : BigFile.DataAccess.BigFile
    {
        public bool Checked { get; set; }

        public override long Length { get => base.Length; set => base.Length = (long)(value / 1024.0 / 1024.0); }

        public BigFileView(DataAccess.BigFile bigFile)
        {
            this.BigFileId = bigFile.BigFileId;
            this.Checked = false;
            this.CreationTime = bigFile.CreationTime;
            this.FileName = bigFile.FileName;
            this.FilePath = bigFile.FilePath;
            this.LastWriteTime = bigFile.LastWriteTime;
            this.Length = bigFile.Length;
        }
    }
}