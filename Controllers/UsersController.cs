using Microsoft.AspNetCore.Mvc;
using Mute.models;
using Mute.repositories;

namespace Mute.controllers
{

    /// <summary>
    /// Controller for the User entity.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private IUsersRepository _usersRepository;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="usersRepository">The IUsersRepository to use.</param>
        public UsersController(IUsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }

        /// <summary>
        /// Retrieves a single user, or returns a 204 no content.
        /// </summary>
        /// <param name="UserId">The ID of the user.</param>
        /// <returns>The found User, or a 204.</returns>
        [HttpGet("{UserId}", Name = "User")]
        public User GetUser(string UserId)
        {
            return _usersRepository.GetUserByUserId(UserId);
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>All users as a list.</returns>
        [HttpGet("", Name = "Users")]
        public List<User> GetUsers()
        {
            return _usersRepository.GetUsers();
        }

    }

}