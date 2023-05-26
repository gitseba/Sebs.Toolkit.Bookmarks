using Sebs.Toolkit.Bookmarks.Base.Abstractions;
using Sebs.Toolkit.Bookmarks.Mozilla.Models;
using Sebs.Toolkit.Databases.Sqlite;
using Sebs.Toolkit.Databases.Sqlite.Abstractions;

namespace Sebs.Toolkit.Bookmarks.Mozilla
{
    /// <summary>
    /// Purpose: 
    /// Created by: sebde
    /// Created at: 5/22/2023 4:03:00 PM
    /// </summary>
    public class FirefoxBookmarksProvider : IBookmarksProvider<BookmarkEntity>
    {
        readonly string _bookmarksSourcePath = string.Empty;
        readonly string _connectionString = string.Empty;
        private readonly string _query;

        //Constructor
        public FirefoxBookmarksProvider(string query, string bookmarksSourcePath = "")
        {
            _query = query;

            if (!string.IsNullOrEmpty(bookmarksSourcePath))
            {
                _bookmarksSourcePath = bookmarksSourcePath;
            }
            else
            {
                //Default installation folder
                _bookmarksSourcePath =
                   $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Mozilla\Firefox\Profiles\amdwacec.default-release\places.sqlite";
            }

            _connectionString = $"Data Source={_bookmarksSourcePath};Version=3;Compress=True;Read Only=True;";
        }

        public IEnumerable<BookmarkEntity> AccessBookmarks()
        {
            ISqliteService sqliteService = new SqliteService();
            var bookmarks = sqliteService.QueryDatabase<BookmarkEntity>(_connectionString, _query);
            return bookmarks;
        }
    }
}
