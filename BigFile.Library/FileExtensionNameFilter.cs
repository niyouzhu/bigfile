using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BigFile.Library
{
    public class FileExtensionNameFilter : IFilter
    {
        public FileExtensionNameFilter(string[] needSearchExtensionNames, string thisFileExtensionName)
        {
            NeedSearchExtensionNames = needSearchExtensionNames;
            ThisFileExtensionName = thisFileExtensionName;
        }

        public string[] NeedSearchExtensionNames { get; }

        public string ThisFileExtensionName { get; }

        public FileExtensionNameFilter(string allowedExtensionNames, string thisFileExtensionName) : this(allowedExtensionNames.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries), thisFileExtensionName)
        {
        }

        public bool Match()
        {
            if (NeedSearchExtensionNames.Contains("*")) return true;
            bool allowed = false;
            Array.ForEach(NeedSearchExtensionNames, it =>
            {
                if (it.Contains(ThisFileExtensionName)) { allowed = true; return; }
            });
            if (allowed) return true;
            return false;
        }
    }
}