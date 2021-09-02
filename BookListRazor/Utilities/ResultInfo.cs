using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Utilities
{
    public class ResultInfo
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public ResultInfo(bool res, string mess)
        {
            Result = res;
            Message = mess;
        }
    }
}
