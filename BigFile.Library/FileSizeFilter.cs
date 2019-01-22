using System;
using System.Collections.Generic;
using System.Text;

namespace BigFile.Library
{
    public class FileSizeFilter : IFilter
    {
        public int AllowedFileSizeMb { get; }
        public int ThisFileSizeMb { get; }

        public FileSizeFilter(int allowedFileSizeMb, int thisFileSizeMb)
        {
            AllowedFileSizeMb = allowedFileSizeMb;
            ThisFileSizeMb = thisFileSizeMb;
        }

        public bool Allow()
        {
            return AllowedFileSizeMb >= ThisFileSizeMb;
        }
    }
}