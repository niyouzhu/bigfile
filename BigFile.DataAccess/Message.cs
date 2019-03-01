using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BigFile.DataAccess
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string FolderPath { get; set; }

        [StringLength(256)]
        public string FilePath { get; set; }

        [StringLength(1024)]
        public string ExceptionMessage { get; set; }

        [StringLength(4096)]
        public string ExceptionLog { get; set; }

        public MessageType MessageType { get; set; }
    }
}