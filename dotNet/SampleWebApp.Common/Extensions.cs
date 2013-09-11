using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;

namespace SampleWebApp.Common
{
    public static class Extensions
    {
        public static string ToSimplifiedNumberText(this int value)
        {
            return value < 1000 ? value.ToString(CultureInfo.InvariantCulture) : string.Format("{0}k", value / 1000);
        }
    }
}
