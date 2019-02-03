using System;
using System.Collections.Generic;
using System.Text;

namespace BigFile.Library
{
    public class FileSizeFilter : IFilter
    {
        public int GreaterThanFileSizeMb { get; }
        public int ThisFileSizeMb { get; }

        public FileSizeFilter(int greaterThanFileSizeMb, int thisFileSizeMb)
        {
            GreaterThanFileSizeMb = greaterThanFileSizeMb;
            ThisFileSizeMb = thisFileSizeMb;
        }

        public bool Match()
        {
            return GreaterThanFileSizeMb <= ThisFileSizeMb;
        }
    }
}