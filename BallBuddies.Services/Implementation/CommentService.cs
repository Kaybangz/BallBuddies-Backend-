using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
