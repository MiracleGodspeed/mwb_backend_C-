using MakeWeBet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models.Entity
{
    public class UserFollowership : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid UserFollowingId { get; set; }
        public FollowershipStatus FollowershipStatus { get; set; }



        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("UserFollowingId")]
        public virtual User UserFollowing { get; set; }
    }
}
