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
        private ITagsRepository _tagsRepository;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="usersRepository">The IUsersRepository to use.</param>
        /// <param name="tagsRepository">The ITagsRepository to use.</param>
        public UsersController(IUsersRepository usersRepository, ITagsRepository tagsRepository)
        {
            this._usersRepository = usersRepository;
            this._tagsRepository = tagsRepository;
        }

        /// <summary>
        /// Retrieves a single user, or returns a 204 no content.
        /// </summary>
        /// <param name="UserId">The ID of the user.</param>
        /// <returns>The found User, or a 204.</returns>
        [HttpGet("{UserId}", Name = "User")]
        public User GetUser(string UserId)
        {
            User? user = _usersRepository.GetUserByUserId(UserId);
            if (user != null) {
                user.UserTags = this.GetTagsByUserId(UserId);
            }
            return user;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>All users as a list.</returns>
        [HttpGet("", Name = "Users")]
        public List<User> GetUsers()
        {
            List<User> users = _usersRepository.GetUsers();

            foreach(User user in users) {
                user.UserTags = this.GetTagsByUserId(user.UserID);
            }

            return users;
        }

        /// <summary>
        /// Retrieves the tags for a given user.
        /// </summary>
        /// <param name="userID">The userID to look up tags for.</param>
        /// <returns>The list of tags to return.</returns>
        private List<Tag> GetTagsByUserId(string userID) {
            return this._tagsRepository.GetTagsByUserId(userID);
        }

    }

}