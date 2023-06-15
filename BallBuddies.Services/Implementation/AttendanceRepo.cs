using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBuddies.Services.Implementation
{
    public class AttendanceRepo: GenericRepository<Attendance>, IAttendanceRepo
    {
        public AttendanceRepo(BallBuddiesDBContext dbContext): base(dbContext)
        {

        }


    }
}
