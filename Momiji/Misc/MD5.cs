using System;
using System.Text;
using System.Security.Cryptography;

namespace Momiji
{
    class MD5
    {
        private string hash;
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

        // returns full hash
        public string getHash(){
            return this.hash.ToLower();
        }

        // returns the first 8 characters of the hash
        public string getShortHash()
        {
            return this.hash.Substring(0, 8).ToLower();

        }

    }
}