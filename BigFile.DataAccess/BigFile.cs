using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BigFile.DataAccess
{
    public class BigFile
    {
        [Key]
        public int BigFileId { get; set; }

        [StringLength(256)]
        public string FileName { get; set; }

        [StringLength(256)]
        public string FilePath { get; set; }

        public DateTime LastWriteTime { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual long Length { get; set; }
    }
}