using System;

namespace left_pad
{
    public static class StringExtensions
    {
        public static string LeftPad(this string str, char ch, int len)
        {
            if (len <= 0)
                throw new InvalidOperationException();

            if (string.IsNullOrEmpty(str))
                return new string(ch, len);

            var i = -1;
            len = len - str.Length;
            while (++i < len)
            {
                str = ch + str;
            }
            return str;
        }
    }
}
