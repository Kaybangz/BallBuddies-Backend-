using AutoMapper;
using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace BallBuddies.Services.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BallBuddiesDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;



        private readonly IUserAuthentication _userAuthentication;


        public UnitOfWork(BallBuddiesDBContext dbContext, IMapper mapper, ILoggerManager logger, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;

            _userAuthentication = new UserAuthentication(_logger, _mapper, userManager);
        }

        public IUserAuthentication UserAuthentication
        {
            get { return _userAuthentication; }
        }

        public async Task DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        void IDisposable.Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
