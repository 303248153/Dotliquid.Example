using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dotliquid.Example.Dotliquid
{
    public class DotliquidCustomFilter
    {
        public static string Substr(string value, int startIndex, int length = -1)
        {
            if (length >= 0)
                return value.Substring(startIndex, length);
            return value.Substring(startIndex);
        }
    }
}