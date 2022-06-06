using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models.Entity
{
    public class UserBetCategorySuggestion : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool IsApproved { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
