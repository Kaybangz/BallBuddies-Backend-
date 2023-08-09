using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<CommentResponseDto>> GetCommentsAsync(int eventId, bool trackChanges)
        {
            var currentEvent = await _unitOfWork.Event.GetEvent(eventId, trackChanges);

            if (currentEvent is null)
                throw new EventNotFoundException(eventId);

            var commentsFromDb = await _unitOfWork.Comment.GetComments(eventId, trackChanges);

            var commentsDto = _mapper.Map<IEnumerable<CommentResponseDto>>(commentsFromDb);

            return commentsDto;
        }
    }
}
