using Mute.models;

namespace Mute.repositories {

    /// <summary>
    /// Interface defining the contract necessary for all UserRepositories.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public interface IUsersRepository {

        /// <summary>
        /// Retrieves a single user by the given user ID, or null if not found.
        /// </summary>
        /// <param name="userId">The user ID of the user to retrieve.</param>
        /// <returns>The user, or null if not found.</returns>
        public User? GetUserByUserId(int userId);

        /// <summary>
        /// Retrieves all of the users.
        /// </summary>
        /// <returns>The users.</returns>
        public List<User> GetUsers();

    }

}