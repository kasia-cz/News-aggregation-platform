﻿namespace NewsPlatform.Data.Entities
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int PositivityRate { get; set; }
        public DateTime PublishTime { get; set; }
        public string SourceLink { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
