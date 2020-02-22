using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Model.TodoItems;

namespace TodoApp.Repository
{
    public class SqliteRepository : IDataRepository<TodoItem>
    {
        private SQLiteAsyncConnection _db;   
        public SqliteRepository(string dbPath)
        {
            if (string.IsNullOrWhiteSpace(dbPath)) 
                throw new ArgumentException("dbPath is null or white space");
            
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<TodoItem>().Wait();
        }

        public async Task<bool> AddItemAsync(TodoItem item)
        {
            bool resultBool;
            try
            {
                int result = await _db.InsertAsync(item);
                resultBool = result != 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
            return resultBool;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            bool resultBool;
            try
            {
                int result = await _db.DeleteAsync<TodoItem>(id);
                resultBool = result == 1 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
            return resultBool;
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            try
            {
               return await _db.GetAsync<TodoItem>(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TodoItem>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                return await _db.Table<TodoItem>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateItemAsync(TodoItem item)
        {
            bool result;
            try
            {
                int res = await _db.UpdateAsync(item);
                result = res == 0 ? false : true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
