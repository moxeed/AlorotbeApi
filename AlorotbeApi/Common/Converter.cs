using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alorotbe.Api.Common
{
    public static class Converter
    {
        public static string TimeString(this TimeSpan time) => $"{time.Hours}:{time.Minutes}";
    }
}
