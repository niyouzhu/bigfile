using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BigFile.Library
{
    public class FileExtensionNameFilter : IFilter
    {
        public FileExtensionNameFilter(string[] allowedExtensionNames, string thisFileExtensionName)
        {
            AllowedExtensionNames = allowedExtensionNames;
            ThisFileExtensionName = thisFileExtensionName;
        }

        public string[] AllowedExtensionNames { get; }

        public string ThisFileExtensionName { get; }

        public FileExtensionNameFilter(string allowedExtensionNames, string thisFileExtensionName) : this(allowedExtensionNames.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries), thisFileExtensionName)
        {
        }

        public bool Allow()
        {
            if (AllowedExtensionNames.Contains("*.*")) return true;
            bool allowed = false;
            Array.ForEach(AllowedExtensionNames, it =>
            {
                if (it.Contains(ThisFileExtensionName)) allowed = true;
            });
            if (allowed) return true;
            return false;
        }
    }
}