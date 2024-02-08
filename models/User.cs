using System.ComponentModel.DataAnnotations.Schema;

namespace Mute.models {

    /// <summary>
    /// Model representing a user's account.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class User {

        public int UserID {get; set;}
        public string Username {get; set;}
        public string Email {get; set;}
        public decimal CurrentLatitude {get; set;}
        public decimal CurrentLongitude {get; set;}
        public List<Tag> UserTags {get; set;} = [];

    }

}