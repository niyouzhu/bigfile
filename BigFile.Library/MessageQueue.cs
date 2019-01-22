using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace BigFile.Library
{
    public class MessageQueue : ConcurrentQueue<Message>
    {
    }
}