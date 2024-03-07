using NewsPlatform.Data.Enums;

namespace NewsPlatform.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public int MinimumPositivityRate { get; set; } = 5;

        public List<Comment> Comments { get; set; }
        public List<Topic> SubscribedTopics { get; set; }
    }
}
