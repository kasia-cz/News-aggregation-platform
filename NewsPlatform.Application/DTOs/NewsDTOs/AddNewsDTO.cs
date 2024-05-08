namespace NewsPlatform.Application.DTOs.NewsDTOs
{
    public class AddNewsDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        //public List<Topic> Topics { get; set; } // add later with some TopicDTO
    }
}
