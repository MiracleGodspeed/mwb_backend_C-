using MakeWeBet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models.Entity
{
    public class Bet : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BetPrivatePasscode { get; set; }
        public string BetCode { get; set; }
        public BetReviewStatus BetReviewStatus { get; set; }
        public BetValidityStatus BetValidityStatus { get; set; }
        public long LikeCount { get; set; }
        public long ReshareCount { get; set; }
        public long CommentCount { get; set; }
        public Guid BetCategoryId { get; set; }
        public DateTime? BetStartDate { get; set; }
        public DateTime? BetEndDate { get; set; }
        public int CreatorBonus { get; set; }




        [ForeignKey("BetCategoryId")]
        public virtual BetCategory BetCategory { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
