using Sebs.Toolkit.Bookmarks.Base.Abstractions;
using Sebs.Toolkit.Bookmarks.Mozilla.Models;

namespace Sebs.Toolkit.Bookmarks.Mozilla.UnitTests
{
    /// <summary>
    /// Purpose: 
    /// Created by: sebde
    /// Created at: 5/22/2023 4:03:00 PM
    /// </summary>
    public class FirefoxBookmarksServiceTests
    {
        [Fact]
        public void Should_Return_Mozzila_Firefox_Bookmarks()
        {
            //Arrange
            var query =
               $"SELECT moz_bookmarks.title, moz_places.url, moz_places.description FROM moz_bookmarks " +
               $"LEFT JOIN moz_places WHERE moz_bookmarks.fk = moz_places.id AND moz_bookmarks.title != 'null' ORDER BY url ASC";

            IBookmarksProvider<BookmarkEntity> service = new FirefoxBookmarksProvider(query);

            //Act
            var bookmarks = service.AccessBookmarks();

            //Assert:
            // !Assert is being done by NotNull and NOT Count because
            // it exists the possibility of the Chrome Browser to not have bookmarks saved
            Assert.NotNull(bookmarks);
        }
    }
}
