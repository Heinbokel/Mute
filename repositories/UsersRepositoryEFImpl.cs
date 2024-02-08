
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Mute.models;
using Mute.repositories.configuration;

namespace Mute.repositories {

    /// <summary>
    /// Repository responsible for managing database requests for the User entity.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class UsersRepositoryEFImpl: IUsersRepository {

        private DataContextEF _entityFramework;
        
        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="EntityFramework">The DataContextEf to use.</param>
        public UsersRepositoryEFImpl(DataContextEF EntityFramework) {
            _entityFramework = EntityFramework;
        }

        /// <summary>
        /// Retrieves a single user by their userID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The user if found, or null.</returns>
        public User? GetUserByUserId(int userID)
        {
            return _entityFramework.Users.Where(u => u.UserID == userID).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>The list of all users.</returns>
        public List<User> GetUsers()
        {
            return _entityFramework.Users.ToList();
        }
    }
}