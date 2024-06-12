using NewsPlatform.Application.DTOs.CommentDTOs;
using NewsPlatform.Application.DTOs.TopicDTOs;

namespace NewsPlatform.Application.DTOs.NewsDTOs
{
    public class ReturnNewsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int PositivityRate { get; set; }
        public DateTime PublishTime { get; set; }
        public string SourceLink { get; set; }

        public List<ReturnCommentDTO> Comments { get; set; }
        public List<ReturnTopicDTO> Topics { get; set; }
    }
}
