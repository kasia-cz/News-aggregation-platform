using Microsoft.AspNetCore.Identity;

namespace NewsPlatform.Data.Entities
{
    public class User : IdentityUser
    {
        public int MinimumPositivityRate { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Topic> SubscribedTopics { get; set; }
    }
}
