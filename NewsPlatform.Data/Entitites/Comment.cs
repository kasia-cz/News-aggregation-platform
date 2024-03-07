namespace NewsPlatform.Data.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid NewsId { get; set; }
        public News News { get; set; }
    }
}
