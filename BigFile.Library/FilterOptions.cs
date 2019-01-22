using System;
using System.Collections.Generic;
using System.Text;

namespace BigFile.Library
{
    public class FilterOptions
    {
        public int AllowedFileSizeMb { get; set; }

        public string[] AllowFileExtensionNames { get; set; }
    }
}