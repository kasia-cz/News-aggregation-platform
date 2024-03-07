namespace NewsPlatform.Data.Entities
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
        public List<News> News { get; set; }
    }
}
