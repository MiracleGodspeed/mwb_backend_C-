using MakeWeBet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models.Response
{
    public class ApiResponseModel<TEntity>
    {
        public TEntity Data { get; set; }
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
    }
}
