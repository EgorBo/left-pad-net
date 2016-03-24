using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// lef-pad using http://left-pad.io/ service
        /// </summary>
        public static async Task<string> LeftPadAsync(this string str, char ch, int len)
        {
            HttpClient client = new HttpClient();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ServiceResult));
            var json = await client.GetStringAsync($"https://api.left-pad.io/?str={str}&len={len}&ch={ch}"); 
            var result = (ServiceResult) serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(json)));

            if (!string.IsNullOrEmpty(result.errorMessage))
                throw new Exception($"Error: {result.errorType}: {result.errorMessage}");

            return result.str;
        }

        public class ServiceResult
        {
            public string str { get; set; }
            public string errorMessage { get; set; }
            public string errorType { get; set; }
        }
    }
}
