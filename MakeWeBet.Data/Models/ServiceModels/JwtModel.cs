using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models.ServiceModels
{
    public class Jwt
    {
        public string AccessToken { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Expires { get; set; }
        //public UserModel UserInfo { get; set; }
        public string TokenIdentity { get; set; }
        public string BasicToken { get; set; }
        //public TwoFAResponseStatus TwoFAStatus { get; set; }
    }

    public class JwtWithRefreshToken : Jwt
    {
        public string RefreshToken { get; set; }
    }
}
