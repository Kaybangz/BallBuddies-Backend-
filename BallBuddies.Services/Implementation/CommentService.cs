using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;

namespace BallBuddies.Services.Implementation
{
    public class CommentService: ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork,
            ILoggerManager logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CommentResponseDto> CreateCommentForEventAsync(int eventId, CommentRequestDto commentRequestDto, bool trackChanges)
        {
            await CheckIfEventExist(eventId, trackChanges);

            var commentEntity = _mapper.Map<Comment>(commentRequestDto);

            _unitOfWork.Comment.CreateCommentForEvent(eventId, commentEntity);

            await _unitOfWork.SaveAsync();

            var commentToReturn = _mapper.Map<CommentResponseDto>(commentEntity);

            return commentToReturn;
        }

        public async Task DeleteCommentForEvent(int eventId, int commentId, bool trackChanges)
        {
            await CheckIfEventExist(eventId, trackChanges);

            var commentForEvent = await GetCommentForEventAndCheckIfItExists(eventId, commentId, trackChanges);

            _unitOfWork.Comment.DeleteCommentForEvent(commentForEvent);

            await _unitOfWork.SaveAsync();
        }

        public async Task<CommentResponseDto> GetCommentAsync(int eventId, int commentId, bool trackChanges)
        {
            await CheckIfEventExist(eventId, trackChanges);

            var commentFromDb = await GetCommentForEventAndCheckIfItExists(eventId, commentId, trackChanges);


            var comment = _mapper.Map<CommentResponseDto>(commentFromDb);

            return comment;
        }

        public async Task<IEnumerable<CommentResponseDto>> GetCommentsAsync(int eventId, bool trackChanges)
        {
            await CheckIfEventExist(eventId, trackChanges);

            var commentsFromDb = await _unitOfWork.Comment.GetComments(eventId, trackChanges);

            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(commentsFromDb);

            return commentsDto;
        }


        private async Task CheckIfEventExist(int eventId, bool trackChanges)
        {
            var existingEvent = await _unitOfWork.Event.GetEvent(eventId, trackChanges);

            if(existingEvent is null)
                throw new EventNotFoundException(eventId);

        }


        private async Task<Comment> GetCommentForEventAndCheckIfItExists(int eventId,
            int commentId,
            bool trackChanges)
        {
            var commentDb = await _unitOfWork.Comment.GetComment(eventId, commentId, trackChanges);

            if (commentDb is null)
                throw new CommentNotFoundException(commentId);

            return commentDb;
        }
    }
}
