using System;
using System.Collections.Generic;
using System.Text;

namespace BigFile.Library
{
    public interface IFilter
    {
        bool Allow();
    }
}