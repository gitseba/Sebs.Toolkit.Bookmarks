using Newtonsoft.Json.Linq;
using Sebs.Toolkit.Bookmarks.Base.Abstractions;
using Sebs.Toolkit.Bookmarks.Google.Models;

namespace Sebs.Toolkit.Bookmarks.Google
{
    /// <summary>
    /// Purpose: 
    /// Created by: sebde
    /// Created at: 5/22/2023 4:03:00 PM
    /// </summary>
    public class ChromeBookmarksProvider : IBookmarksProvider<BookmarkEntity>
    {
        readonly string _bookmarksSourcePath = string.Empty;

        #region Constructor
        public ChromeBookmarksProvider(string bookmarksSourcePath = "")
        {
            if (!string.IsNullOrEmpty(bookmarksSourcePath))
            {
                _bookmarksSourcePath = bookmarksSourcePath;
            }
            else
            {
                //Default installation folder
                _bookmarksSourcePath =
                   $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Google\Chrome\User Data\Default\Bookmarks";
            }
        }
        #endregion

        public IEnumerable<BookmarkEntity> AccessBookmarks()
        {
            JObject data = JObject.Parse(File.ReadAllText(_bookmarksSourcePath));
            var bookmarks = data?.SelectToken(@"roots.bookmark_bar.children")?.ToObject<IReadOnlyList<BookmarkEntity>>();

            //No need to iterate if there are no saved bookmarks
            if (bookmarks == null || bookmarks.Count == 0)
            {
                yield return (BookmarkEntity)Enumerable.Empty<BookmarkEntity>();
            }
            else
            {
                foreach (var bookmark in bookmarks)
                {
                    yield return bookmark;
                }
            }
        }
    }
}
