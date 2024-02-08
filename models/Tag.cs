namespace Mute.models
{
    /// <summary>
    /// Model representing a tag on a user's profile.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class Tag
    {
        public string TagId { get; set; }
        public string TagName { get; set; }

        /// <summary>
        /// Complete constructor for the Tag class.
        /// </summary>
        /// <param name="tagId">The ID of the tag.</param>
        /// <param name="tagName">The display name of the tag.</param>
        public Tag(string tagId, string tagName) {
            this.TagId = tagId;
            this.TagName = tagName;
        }

    }
}