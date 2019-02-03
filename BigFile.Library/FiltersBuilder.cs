using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BigFile.Library
{
    public class FiltersBuilder
    {
        public FiltersBuilder()
        {
            Filters = new Filters();
        }

        public Filters Filters { get; }

        public Filters Build(FilterOptions options, FileInfo fileInfo)
        {
            if (options.AllowedFileSizeMb != 0)
            {
                Filters.Add(new FileSizeFilter(options.AllowedFileSizeMb, (int)(fileInfo.Length / 1024.0 / 1024.0)));
            }
            if (options.NeedSearchFileExtensionNames != null)
            {
                Filters.Add(new FileExtensionNameFilter(options.NeedSearchFileExtensionNames, fileInfo.Extension));
            }
            return Filters;
        }
    }
}