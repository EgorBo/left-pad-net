using System;

namespace left_pad
{
    public static class StringExtensions
    {
        public static string LeftPad(this string str, char ch, int len)
        {
            if (len <= 0)
                throw new InvalidOperationException();

            return new string(ch, Math.Max(len - str?.Length ?? 0, 0)) + str;
        }
    }
}
