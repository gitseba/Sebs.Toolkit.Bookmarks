namespace Sebs.Toolkit.Bookmarks.Base.Abstractions
{
    /// <summary>
    /// Purpose: Interface for all bookmarks service providers
    /// Created by: sebde
    /// Created at: 5/22/2023 4:01:08 PM
    /// </summary>
    public interface IBookmarksProvider<T> 
        where T : class, new() 
    {      
        IEnumerable<T> AccessBookmarks();
    }
}

