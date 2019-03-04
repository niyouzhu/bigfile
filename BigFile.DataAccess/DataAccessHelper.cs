using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BigFile.DataAccess
{
    public class DataAccessHelper
    {
        public static BigFile Add(BigFile bigFile)
        {
            using (var db = new BigFileDbContext())
            {
                db.BigFiles.Add(bigFile);
                db.SaveChanges();
                return bigFile;
            }
        }

        public static Message Add(Message message)
        {
            using (var db = new BigFileDbContext())
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return message;
            }
        }

        public static IEnumerable<BigFile> Search(string fileNameLike, long? greaterThanfileSize, int pageIndex = 0, int pageSize = 100)
        {
            using (var db = new BigFileDbContext())
            {
                var queryable = db.BigFiles as IQueryable<BigFile>;
                if (!string.IsNullOrWhiteSpace(fileNameLike)) queryable = queryable.Where(it => it.FileName.Contains(fileNameLike));
                if (greaterThanfileSize != null) queryable = queryable.Where(it => it.Length >= greaterThanfileSize);
                queryable = queryable.Skip(pageIndex * pageSize).Take(pageSize);
                return queryable.ToList();
            }
        }

        public static IEnumerable<Message> Search(string exceptionMessageLike, string fileOrFolderNameLike, MessageType? messageType, int pageIndex = 0, int pageSize = 100)
        {
            using (var db = new BigFileDbContext())
            {
                var queryable = db.Messages as IQueryable<Message>;
                if (!string.IsNullOrWhiteSpace(exceptionMessageLike)) queryable = queryable.Where(it => it.ExceptionMessage.Contains(exceptionMessageLike));
                if (!string.IsNullOrWhiteSpace(fileOrFolderNameLike)) queryable = queryable.Where(it => it.FilePath.Contains(fileOrFolderNameLike) || it.FolderPath.Contains(fileOrFolderNameLike));
                if (messageType != null) queryable = queryable.Where(it => it.MessageType == messageType);
                queryable = queryable.Skip(pageIndex * pageSize).Take(pageSize);
                return queryable.ToList();
            }
        }

        public static int Delete(Message message)
        {
            using (var db = new BigFileDbContext())
            {
                db.Messages.Attach(message);
                foreach (var item in db.ChangeTracker.Entries())
                {
                    item.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }

        public static int Delete(IEnumerable<Message> messages)
        {
            using (var db = new BigFileDbContext())
            {
                db.Messages.AttachRange(messages);
                foreach (var item in db.ChangeTracker.Entries())
                {
                    item.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }

        public static int Delete(string filePath)
        {
            using (var db = new BigFileDbContext())
            {
                var existing = db.BigFiles.Where(it => it.FilePath == filePath);
                db.BigFiles.RemoveRange(existing);
                return db.SaveChanges();
            }
        }

        public static int Delete(BigFile bifFile)
        {
            using (var db = new BigFileDbContext())
            {
                db.AttachRange(bifFile);
                foreach (var item in db.ChangeTracker.Entries())
                {
                    item.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }

        public static int Delete(IEnumerable<BigFile> bigFile)
        {
            using (var db = new BigFileDbContext())
            {
                db.AttachRange(bigFile);
                foreach (var item in db.ChangeTracker.Entries())
                {
                    item.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }

        public static void Clear()
        {
            using (var db = new BigFileDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}