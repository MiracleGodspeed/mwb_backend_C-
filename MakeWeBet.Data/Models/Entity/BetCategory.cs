using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models.Entity
{
    public class BetCategory : BaseEntity
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
