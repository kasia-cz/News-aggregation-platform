namespace NewsPlatform.Application.DTOs.CommentDTOs
{
    public class ReturnCommentDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishTime { get; set; }
        public string UserName { get; set; }
    }
}
