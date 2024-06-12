namespace NewsPlatform.Application.DTOs.NewsDTOs
{
    public class ReturnNewsShortDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int PositivityRate { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
