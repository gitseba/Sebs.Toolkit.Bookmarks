using Dapper;
using Sebs.Toolkit.Databases.Sqlite.Abstractions;
using System.Data.SQLite;

namespace Sebs.Toolkit.Databases.Sqlite
{
    /// <summary>
    /// Purpose: 
    /// Created by: sebde
    /// Created at: 5/22/2023 4:19:42 PM
    /// </summary>
    public class SqliteService : ISqliteService
    {
        private SQLiteConnection? _connection = null;
        public IEnumerable<T> QueryDatabase<T>(string connectionString, string sqlQuery)
        {
            using (_connection = new SQLiteConnection(connectionString))
            {
                var bookmarks = _connection.Query<T>(sqlQuery);
                _connection.CloseAsync();
                foreach (var bookmark in bookmarks)
                {
                    yield return bookmark;
                }
            }
        }

        #region Asynchronous Alternative (downside: ~100ms + to execute)
        //public async Task<IEnumerable<T>> QueryDatabaseAsync<T>(string connectionString, string sqlQuery)
        //{
        //    try
        //    {
        //        using (_connection = new SQLiteConnection(connectionString))
        //        {
        //            var bookmarks = await _connection.QueryAsync<T>(sqlQuery);
        //            await _connection.CloseAsync();
        //            return bookmarks;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        #endregion
    }
}
