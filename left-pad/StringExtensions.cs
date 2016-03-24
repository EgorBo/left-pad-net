namespace left_pad
{
    public static class StringExtensions
    {
        public static string LeftPad(char ch, int len)
        {
            var str = "";
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
