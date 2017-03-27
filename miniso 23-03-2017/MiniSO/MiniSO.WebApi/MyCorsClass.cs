using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniSO.WebApi
{
    public class MyCorsClass
    {
        public static string GetEnableCorsOrigins()
        {
            return "http://localhost:54241";
        }
    }
}