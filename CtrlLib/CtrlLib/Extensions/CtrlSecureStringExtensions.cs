using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CtrlLib.Extensions
{
    public static class CtrlSecureStringExtensions
    {
        public static string ConvertToUnsecureString(this SecureString iValue)
        {
            if (iValue == null)
                throw new ArgumentNullException("iValue");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(iValue);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static string ConvertToSha256HexString(this SecureString iValue)
        {
            var sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                var result = hash.ComputeHash(enc.GetBytes(iValue.ConvertToUnsecureString()));

                foreach (var b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
