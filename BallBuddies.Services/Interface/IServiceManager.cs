using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBuddies.Services.Interface
{
    public interface IServiceManager
    {
        IEventService EventService { get; }
        IAttendanceService AttendanceService { get; }
        ICommentService CommentService { get; }
    }
}
