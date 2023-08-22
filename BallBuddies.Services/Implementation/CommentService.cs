using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BallBuddies.Services.Implementation
{
    public class CommentService: ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentService(IUnitOfWork unitOfWork,
            ILoggerManager logger,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<CommentResponseDto> CreateCommentForEventAsync(Guid eventId, CommentRequestDto commentRequestDto, bool trackChanges)
        {
            var userId = _httpContextAccessor
                .HttpContext
                ?.User
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;


            await CheckIfEventExist(eventId, trackChanges);

            var commentEntity = _mapper.Map<Comment>(commentRequestDto);

            _unitOfWork.Comment.CreateCommentForEvent(userId, eventId, commentEntity);

            await _unitOfWork.SaveAsync();

            var commentToReturn = _mapper.Map<CommentResponseDto>(commentEntity);

            return commentToReturn;
        }

        public async Task DeleteCommentForEvent(Guid eventId, Guid commentId, bool trackChanges)
        {
            var userId = _httpContextAccessor
                .HttpContext
                ?.User
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;


            await CheckIfEventExist(eventId, trackChanges);

            var commentForEvent = await GetCommentForEventAndCheckIfItExists(eventId, commentId, trackChanges);

            if(commentForEvent.UserId != userId)
                throw new UnauthorizedAccessException("You do not have permission to " +
                    "delete this comment.");

            _unitOfWork.Comment.DeleteCommentForEvent(commentForEvent);

            await _unitOfWork.SaveAsync();
        }

        public async Task<CommentResponseDto> GetCommentAsync(Guid eventId, Guid commentId, bool trackChanges)
        {
            await CheckIfEventExist(eventId, trackChanges);

            var commentFromDb = await GetCommentForEventAndCheckIfItExists(eventId, commentId, trackChanges);


            var comment = _mapper.Map<CommentResponseDto>(commentFromDb);

            return comment;
        }

        public async Task<IEnumerable<CommentResponseDto>> GetCommentsAsync(Guid eventId, bool trackChanges)
        {
            await CheckIfEventExist(eventId, trackChanges);

            var commentsFromDb = await _unitOfWork.Comment.GetComments(eventId, trackChanges);

            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(commentsFromDb);

            return commentsDto;
        }


        private async Task<Event> CheckIfEventExist(Guid eventId, bool trackChanges)
        {
            var existingEvent = await _unitOfWork.Event.GetEvent(eventId, trackChanges);

            if(existingEvent is null)
            {
                _logger.LogError($"Event with Id: {eventId} not found");
                throw new EventNotFoundException(eventId);
            }

            return existingEvent;
        }


        private async Task<Comment> GetCommentForEventAndCheckIfItExists(Guid eventId,
            Guid commentId,
            bool trackChanges)
        {
            var commentDb = await _unitOfWork.Comment.GetComment(eventId, commentId, trackChanges);

            if (commentDb is null)
                throw new CommentNotFoundException(commentId);

            return commentDb;
        }
    }
}
