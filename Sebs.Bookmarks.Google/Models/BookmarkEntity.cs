using Newtonsoft.Json;

namespace Sebs.Toolkit.Bookmarks.Google.Models
{
    /// <summary>
    /// Purpose: Model for Mozzila bookmark database
    /// Created by: sebde
    /// Created at: 5/22/2023 3:58:56 PM
    /// </summary>
    public class BookmarkEntity
    {
        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}
