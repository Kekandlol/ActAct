using Microsoft.AspNetCore.DataProtection;
using System.Diagnostics;
using System.Text;

namespace StrangerThings
{
    public class ProtectorProv : IDataProtectionProvider
    {
        public IDataProtector CreateProtector(string purpose)
        {            
            return new Protector();
        }
    }

    public class Protector : IDataProtector
    {
        public IDataProtector CreateProtector(string purpose)
        {
            return this;
        }

        public byte[] Protect(byte[] plaintext)
        {
           Debug.WriteLine("Protect");
           Debug.WriteLine(Encoding.UTF8.GetString(plaintext
               .Where(c => c > 31).ToArray()));
            return plaintext;
        }

        public byte[] Unprotect(byte[] protectedData)
        {
           Debug.WriteLine("Unprotect");
           Debug.WriteLine(Encoding.UTF8.GetString(protectedData
               .Where(c=>c > 31).ToArray()));
            return protectedData;
        }
    }
}
