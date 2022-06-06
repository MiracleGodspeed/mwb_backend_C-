using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Enums
{
    public enum BetResult
    {
        InProgress = 1,
        Won,
        Lost
    }


    public enum BetInvitationAction
    {
        Pending = 1,
        Accepted,
        Declined
    }
}
