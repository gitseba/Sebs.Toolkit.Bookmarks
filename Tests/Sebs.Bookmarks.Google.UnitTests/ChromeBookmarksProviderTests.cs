using Sebs.Toolkit.Bookmarks.Base.Abstractions;
using Sebs.Toolkit.Bookmarks.Google.Models;

namespace Sebs.Toolkit.Bookmarks.Google.UnitTests
{
    /// <summary>
    /// Purpose: Test the Chrome Bookmarks Service
    /// Created by: sebde
    /// Created at: 5/22/2023 4:07:00 PM
    /// </summary>
    public class ChromeBookmarksProviderTests
    {
        [Fact]
        public void Should_Return_Google_Chrome_Bookmarks()
        {
            //Arrange
            IBookmarksProvider<BookmarkEntity> provider = new ChromeBookmarksProvider();

            //Act
            var bookmarks = provider.AccessBookmarks();

            //Assert:
            // !Assert is being done by NotNull and NOT Count because
            // it exists the possibility of the Chrome Browser to not have bookmarks saved
            Assert.NotNull(bookmarks);
        }
    }
}
