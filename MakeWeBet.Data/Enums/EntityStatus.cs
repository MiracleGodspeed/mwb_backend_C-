using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Enums
{
    public enum EntityStatus
    {
        ACTIVE = 1,
        INACTIVE,
    }


    public enum FollowershipStatus
    {
        FOLLOWING = 1,
        UNFOLLOWED,
        BLOCKED
    }
}
