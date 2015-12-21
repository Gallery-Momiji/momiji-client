using System;
using System.Text;
using System.Security.Cryptography;

namespace Momiji
{
    class MD5
    {
        public string hash;
        public MD5(string data)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(data);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            this.hash = ByteArrayToString(tmpHash);
        }

        private string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
