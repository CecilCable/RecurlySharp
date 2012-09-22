using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RecurlySharp{
    public class Signature{
        private static readonly DateTime UnixEpoch =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private static long LocalTimeToUnixTimestampSeconds(DateTime localTime){
            return (long) (localTime.ToUniversalTime() - UnixEpoch).TotalSeconds;
        }

        private readonly string _key;

        public Signature(string privateKey){
            _key = privateKey;
        }

        public string Sign(params KeyValuePair<string, string>[] kvps){
            return Sign(Guid.NewGuid().ToString("N"), DateTime.Now, kvps);
        }

        /// <summary>
        ///   Usefull for testing encryption refactoring so that I can generate the same signature twice
        /// </summary>
        /// <param name="nonce"> </param>
        /// <param name="localtime"> </param>
        /// <param name="kvp"> </param>
        /// <returns> </returns>
        public string Sign(string nonce, DateTime localtime, IEnumerable<KeyValuePair<string, string>> kvp){
            var timestamp = LocalTimeToUnixTimestampSeconds(localtime);
// ReSharper disable SpecifyACultureInStringConversionExplicitly
            var otherSignature = new[]{new KeyValuePair<string, string>("nonce", nonce), new KeyValuePair<string, string>("timestamp", timestamp.ToString())};
// ReSharper restore SpecifyACultureInStringConversionExplicitly

            var urlEncoded = string.Join("&", otherSignature.Union(kvp).Select(item => HttpUtility.UrlEncode(item.Key) + "=" + HttpUtility.UrlEncode(item.Value)));
            return string.Format("{0}|{1}", Sign(urlEncoded), urlEncoded);
        }


        private string Sign(string something){
            var keyByte = GetBytes(_key);


            var hmacsha1 = new HMACSHA1(keyByte, true);
            var message = GetBytes(something);
            var hash = hmacsha1.ComputeHash(message);

            var formatted = new StringBuilder(hash.Length);
            foreach(var b in hash){
                formatted.AppendFormat("{0:X2}", b);
            }
            return formatted.ToString().ToLower();
        }

        private static byte[] GetBytes(string str){
            //byte[] bytes = new byte[str.Length * sizeof(char)];
            //System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            //return bytes;
            var encoding = new ASCIIEncoding();

            var keyByte = encoding.GetBytes(str);
            return keyByte;
        }
    }
}