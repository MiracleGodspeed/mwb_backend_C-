using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Enums
{
    public enum ModeratorDisputeStatus
    {
        AwaitingAction = 1,
        IsDisputed,
        IsApproved
    }

    public enum ModeratorAssignmentStatus
    {
        SystemAssigned = 1,
        UserAssigned
    }
}
