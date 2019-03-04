using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Threading;

namespace BigFile.Library
{
    public class BigFileFinder
    {
        public string RootFolder { get; }

        private MessageQueue _messages;

        private FileQueue _allFiles;

        private DirectoryQueue _directories;

        public FilterOptions FilterOptions { get; }

        public bool Stop
        {
            get { return _stop; }
            set
            {
                if (value)
                {
                    ManualResetEventSlim.Reset();
                }
                else
                {
                    ManualResetEventSlim.Set();
                }
                _stop = value;
            }
        }

        private bool _stop;

        private ManualResetEventSlim ManualResetEventSlim = new ManualResetEventSlim(true);

        public MessageQueue Messages
        {
            get
            {
                if (_messages == null) _messages = new MessageQueue();
                _messages.Enqueued += () => NewMessageArrived?.Invoke(_messages);
                return _messages ?? (_messages = new MessageQueue());
            }
        }

        public FileQueue AllFiles
        {
            get
            {
                if (_allFiles == null)
                {
                    _allFiles = new FileQueue();
                    _allFiles.Enqueued += () =>
                   {
                       if (_allFiles.TryDequeue(out FileInfo file))
                       {
                           try
                           {
                               Filter(file);
                           }
                           catch (Exception ex)
                           {
                               Messages.Enqueue(new Message() { Exception = ex, FilePath = file.FullName, FolderPath = file.DirectoryName });
                           }
                       }
                   };
                }
                return _allFiles;
            }
        }

        public FileQueue MatchedFiles
        {
            get
            {
                if (_matchedFiles == null)
                {
                    _matchedFiles = new FileQueue();
                    _matchedFiles.Enqueued += () => Matched?.Invoke(MatchedFiles);
                }
                return _matchedFiles ?? (_matchedFiles = new FileQueue());
            }
        }

        public event Action<FileQueue> Matched;

        public event Action<MessageQueue> NewMessageArrived;

        private FileQueue _matchedFiles;

        public DirectoryQueue Directories
        {
            get
            {
                if (_directories == null)
                {
                    _directories = new DirectoryQueue();
                    _directories.Enqueued += async () =>
                    {
                        if (_directories.TryDequeue(out DirectoryInfo directory))
                        {
                            try
                            {
                                await StoreFiles(directory).ConfigureAwait(false);
                            }
                            catch (Exception ex)
                            {
                                Messages.Enqueue(new Message() { Exception = ex, FolderPath = directory.FullName });
                            }
                        }
                    };
                }
                return _directories;
            }
        }

        public BigFileFinder(string rootFolder, FilterOptions filterOptions)
        {
            RootFolder = rootFolder;
            FilterOptions = filterOptions;
        }

        private void StoreDirectories(DirectoryInfo directory)
        {
            if (!ManualResetEventSlim.IsSet)
            {
                ManualResetEventSlim.Wait();
            }
            Directories.Enqueue(directory);
            var directories = directory.GetDirectories("*", SearchOption.TopDirectoryOnly);
            if (directories.Length > 0)
            {
                directories.ForEach
                    (it =>
               {
                   try
                   {
                       StoreDirectories(it);
                   }
                   catch (Exception ex)
                   {
                       Messages.Enqueue(new Message() { Exception = ex, FolderPath = it.FullName });
                   }
               }

                );
            }
        }

        private Task StoreFiles(DirectoryInfo directoryInfo)
        {
            return Task.Run(() =>
          {
              try
              {
                  var topFiles = directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly);
                  AllFiles.Enqueue(topFiles);
              }
              catch (Exception ex)
              {
                  Messages.Enqueue(new Message() { Exception = ex, FolderPath = directoryInfo.FullName });
              }
          });
        }

        public void Filter(FileInfo fileInfo)
        {
            var filters = new FiltersBuilder().Build(FilterOptions, fileInfo);
            if (filters.Match())
            {
                MatchedFiles.Enqueue(fileInfo);
            }
        }

        public Task<bool> Scan()
        {
            return Task.Run(() =>
            {
                var rootFolder = new DirectoryInfo(RootFolder);
                StoreDirectories(rootFolder);
                return true;
            });
        }
    }
}