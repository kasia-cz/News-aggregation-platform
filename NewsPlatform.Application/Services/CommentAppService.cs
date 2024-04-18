using AutoMapper;
using NewsPlatform.Application.DTOs.CommentDTOs;
using NewsPlatform.Application.Interfaces;
using NewsPlatform.Data.Entities;
using NewsPlatform.Domain.Interfaces;

namespace NewsPlatform.Application.Services
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentAppService(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public async Task<List<ReturnCommentDTO>> AddComment(AddCommentDTO requestCommentDTO)
        {
            var requestComment = _mapper.Map<Comment>(requestCommentDTO);
            var commentList = await _commentService.AddComment(requestComment);

            return _mapper.Map<List<ReturnCommentDTO>>(commentList); // return author's username (map user id to username)
        }

        public async Task<List<ReturnCommentDTO>> DeleteComment(Guid id)
        {
            var commentList = await _commentService.DeleteComment(id);

            return _mapper.Map<List<ReturnCommentDTO>>(commentList); // same
        }

        public async Task<List<ReturnCommentDTO>> GetNewsComments(Guid newsId)
        {
            var commentList = await _commentService.GetNewsComments(newsId);

            return _mapper.Map<List<ReturnCommentDTO>>(commentList); // same
        }
    }
}
