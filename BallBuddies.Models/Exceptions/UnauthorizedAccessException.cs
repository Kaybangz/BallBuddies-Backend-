using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBuddies.Models.Exceptions
{
    internal class UnauthorizedAccessException : BadRequestException
    {
        public UnauthorizedAccessException(string message) : base("Invalid username or password.")
        {
        }
    }
}
