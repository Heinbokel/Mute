
using System.Data;
using DotnetAPI.Repositories.Configuration;
using Microsoft.AspNetCore.Http.HttpResults;
using Mute.models;

namespace Mute.repositories {

    public class UsersRepositoryEFImpl: IUsersRepository {

        private DataContextEF _entityFramework;
        
        public UsersRepositoryEFImpl(DataContextEF EntityFramework) {
            _entityFramework = EntityFramework;
        }

        public User? GetUserByUserId(int userID)
        {
            return _entityFramework.Users.Where(u => u.UserID == userID).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _entityFramework.Users.ToList<User>();
        }
    }
}