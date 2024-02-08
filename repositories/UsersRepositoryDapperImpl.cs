using System.Data;
using Dapper;
using Mute.models;

namespace Mute.repositories {

    /// <summary>
    /// Repository responsible for managing database requests for the User entity.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class UsersRepositoryDapperImpl : IUsersRepository
    {
        // Retrieves ALL Users.
        private static readonly string GET_USERS_SQL = @"
            SELECT
                UserID,
                Username,
                Email,
                CurrentLatitude,
                CurrentLongitude
            FROM
                Users";

        // Appends GET_USERS_SQL to retrieve only a SINGLE User.
        private static readonly string WHERE_USER_ID_EQUALS = @"
            WHERE
                Users.UserID = @USER_ID
        ";

        private IDbConnection _dbConnection;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="dbConnection">The IDbConnection to use.</param>
        public UsersRepositoryDapperImpl(IDbConnection dbConnection) {
            this._dbConnection = dbConnection;
        }
        
        /// <summary>
        /// Retrieves a single user by their userID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The user if found, or null.</returns>
        public User? GetUserByUserId(string userID)
        {
            // Defines the parameters that will be sent into the SQL.
            var Params = new {
                USER_ID = userID
            };

            // Queries for and returns the found User (or null if not found by using QueryFirstOrDefault)
            return _dbConnection.QueryFirstOrDefault<User>(GET_USERS_SQL + WHERE_USER_ID_EQUALS, Params);
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>The list of all users.</returns>
        public List<User> GetUsers()
        {
            return this._dbConnection.Query<User>(GET_USERS_SQL).ToList();
        }
    }

}