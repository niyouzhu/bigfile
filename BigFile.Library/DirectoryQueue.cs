using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BigFile.Library
{
    public class DirectoryQueue : ConcurrentQueueWrapper<DirectoryInfo>
    {
    }
}