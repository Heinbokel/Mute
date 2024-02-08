using Mute.models;

namespace Mute.repositories {

    /// <summary>
    /// Interface defining the contract necessary for all TagsRepositories.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public interface ITagsRepository {

        /// <summary>
        /// Retrieves all tags for the given user ID.
        /// </summary>
        /// <param name="userID">The user ID that the tags are assigned to.</param>
        /// <returns>The list of tags assigned to the given user.</returns>
        public List<Tag> GetTagsByUserId(int userID);

    }

}