namespace NewsPlatform.Application.DTOs.NewsDTOs
{
    public class ReturnNewsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int PositivityRate { get; set; }
        public DateTime PublishTime { get; set; }

        //public List<Comment> Comments { get; set; } // add later with some DTOs
        //public List<Topic> Topics { get; set; }
    }
}
