using System.Data;
using Dapper;
using Mute.models;

namespace Mute.repositories {

    /// <summary>
    /// Repository responsible for managing database requests for the Tags entity.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class TagsRepositoryDapperImpl : ITagsRepository
    {
        // Retrieves the list of tags for the given user ID.
        private static readonly string GET_USER_TAGS = @"
            SELECT
                UserTags.TagID,
                UserTags.UserID,
                Tags.TagName
            FROM    
                UserTags
            JOIN
                Tags
            ON
                UserTags.TagID = Tags.TagID
            WHERE
                UserTags.UserID = @USER_ID";

        private IDbConnection _dbConnection;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="dbConnection">The IDbConnection to use.</param>
        public TagsRepositoryDapperImpl(IDbConnection dbConnection) {
            this._dbConnection = dbConnection;
        }
        
        /// <summary>
        /// Retrieves all tags for a given user ID.
        /// </summary>
        /// <param name="userID">The user ID the tags are assigned to.</param>
        /// <returns>The list of tags belonging to the user.</returns>
        public List<Tag> GetTagsByUserId(int userID) {
            // Defines the parameters that will be sent into the SQL.
            var Params = new {
                USER_ID = userID
            };
            return this._dbConnection.Query<Tag>(GET_USER_TAGS, Params).ToList();
        }
    }

}