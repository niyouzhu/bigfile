using System;
using System.Collections.Generic;
using System.Text;

namespace BigFile.Library
{
    public class Message
    {
        public string FilePath { get; set; }
        public Exception Exception { get; set; }
    }
}