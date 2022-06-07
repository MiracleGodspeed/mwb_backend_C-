using MakeWeBet.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models.Entity
{
    public class User
    {
        public  Guid Id { get; set; }
        public SystemRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityUserId { get; set; }
        public string ClientIpAddress { get; set; }
        public Guid CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
    }
}
