using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FinalApp
{

    class TriplogDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<TriplogDatabase> Instance = new AsyncLazy<TriplogDatabase>(async () =>
        {
            var instance = new TriplogDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Triplog>();
            return instance;
        });

        public TriplogDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Triplog>> GetLogEntryListAsync()
        {
            return Database.Table<Triplog>().ToListAsync();
        }

        public Task<List<Triplog>> GetLogEntryListNotDoneAsync()
        {
            return Database.QueryAsync<Triplog>("SELECT * FROM [Triplog]");
        }

        public Task<Triplog> GetLogEntryAsync(int id)
        {
            return Database.Table<Triplog>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveLogEntryAsync(Triplog logEntry)
        {
            if (logEntry.ID != 0)
            {
                return Database.UpdateAsync(logEntry);
            }
            else
            {
                return Database.InsertAsync(logEntry);
            }
        }

        public Task<int> DeleteLogEntryAsync(Triplog logEntry)
        {
            return Database.DeleteAsync(logEntry);
        }
    }
}
