using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Enums
{
    public enum UserNotificationType
    {
        BetInvitation = 1,
        ModeratorDisputed,
        ModeratorAccepted,
        BetResult
    }

    public enum NotificationCategory
    {
        Email = 1,
        Text
    }

}
