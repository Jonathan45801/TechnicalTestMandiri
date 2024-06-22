using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Misc
{
    public class Utils
    {
       
        public static long DateToTimestamps(DateTime tm)
        {
            long aa = (tm.Ticks - 621355968000000000) / 10000000 * 1000;
            return (tm.Ticks - 621355968000000000) / 10000000 * 1000;
        }
    }
}
