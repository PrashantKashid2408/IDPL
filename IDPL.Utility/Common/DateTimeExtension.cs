using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shiksha.Utility.Common
{
    public static class DateTimeExtension
    {
        public static bool TryParseExact(this string input, string format, out DateTime result)
        {
            return DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }
    }
}
