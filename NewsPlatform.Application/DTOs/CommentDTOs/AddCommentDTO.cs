namespace NewsPlatform.Application.DTOs.CommentDTOs
{
    public class AddCommentDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid NewsId { get; set; }
    }
}
