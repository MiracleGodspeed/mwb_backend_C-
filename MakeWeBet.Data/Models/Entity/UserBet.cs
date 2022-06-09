using MakeWeBet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models.Entity
{
    public class UserBet : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BetId { get; set; }
        public long BetAmount { get; set; }
        public BetResponse SelectedBetResponse { get; set; }
        public BetPairingStatus PairingStatus { get; set; }
        public BetResult BetResult { get; set; }


        [ForeignKey("BetId")]
        public virtual Bet Bet { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
