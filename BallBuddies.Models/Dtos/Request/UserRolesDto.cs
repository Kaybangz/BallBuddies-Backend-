using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBuddies.Models.Dtos.Request
{
    public record UserRolesDto(
        List<string> Roles
        );
}
