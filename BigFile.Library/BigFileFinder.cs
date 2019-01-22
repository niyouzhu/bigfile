using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace BigFile.Library
{
    public class BigFileFinder
    {
        public string RootFolder { get; }

        private MessageQueue _messages;

        private FileQueue _allFiles;

        private DirectoryQueue _directories;

        public FilterOptions FilterOptions { get; }

        public MessageQueue Messages
        {
            get
            {
                if (_messages == null) _messages = new MessageQueue();
                return _messages;
            }
        }

        public FileQueue AllFiles
        {
            get
            {
                if (_allFiles == null) _allFiles = new FileQueue();
                return _allFiles;
            }
        }

        public FileQueue AllowedFiles
        {
            get
            {
                if (_allowedFiles == null) _allowedFiles = new FileQueue();
                return _allowedFiles;
            }
        }

        private FileQueue _allowedFiles;

        public DirectoryQueue Directories
        {
            get
            {
                if (_directories == null) _directories = new DirectoryQueue();
                return _directories;
            }
        }

        public BigFileFinder(string rootFolder, FilterOptions filterOptions)
        {
            RootFolder = rootFolder;
            FilterOptions = filterOptions;
        }

        public Task GetAllFiles()
        {
            var directory = new DirectoryInfo(RootFolder);
            return GetAllFiles(directory);
        }

        private Task GetAllFiles(DirectoryInfo directory)
        {
            try
            {
                var topFiles = directory.GetFiles("*", SearchOption.TopDirectoryOnly);
                AllFiles.Enqueue(topFiles);
                foreach (var topDirectory in directory.GetDirectories("*", SearchOption.TopDirectoryOnly))
                {
                    GetAllFiles(topDirectory);
                }
            }
            catch (Exception ex)
            {
                Messages.Enqueue(new Message() { Exception = ex });
            }

            return Task.CompletedTask;
        }

        public Task Scan()
        {
            GetAllFiles();
            while (true)
            {
                FileInfo fileInfo;
                if (AllFiles.TryDequeue(out fileInfo))
                {
                    var filters = new Filters
                    {
                        new FileExtensionNameFilter(FilterOptions.AllowFileExtensionNames, fileInfo.Extension),
                        new FileSizeFilter(FilterOptions.AllowedFileSizeMb, (int)(fileInfo.Length / 1024.0 / 1024.0))
                    };
                    if (filters.Allow())
                    {
                        AllowedFiles.Enqueue(fileInfo);
                    }
                }
            }
        }
    }
}