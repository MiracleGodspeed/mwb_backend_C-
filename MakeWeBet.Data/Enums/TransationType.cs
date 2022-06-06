using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Enums
{
    public enum TransationType
    {
        Deposit = 1,
        Withdrawal
    }


    public enum TransationStatus
    {
        Pending = 1,
        Successful,
        Failed
    }
}
