using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstitutionCipher
{
    class SubstitutionCipher
    {
        private string key { get; set; }

        public SubstitutionCipher()
        {
            GenerateKey();
        }

        public void GenerateKey()
        {
            byte[] baseAlphabet = new byte[26];
            int[] order = new int[26];
            byte[] keyAlphabet = new byte[26];
            int i = 0;
            int j = 0;
            for (i = 0; i < 26; i++)
            {
                baseAlphabet[i] = (byte)(i + 65);
                order[i] = i;
            }



            Random rnd = new Random();
            while (i > 1)
            {
                int pos = rnd.Next(0, i);
                keyAlphabet[j] = baseAlphabet[pos];
                baseAlphabet = RemoveIndex(baseAlphabet, pos);
                i--;
                j++;
            }
            keyAlphabet[j] = baseAlphabet[i - 1];
            key = Encoding.ASCII.GetString(keyAlphabet);
        }

        // remove an element at exactly position from an array of bytes
        private byte[] RemoveIndex(byte[] source, int index)
        {
            byte[] dest = new byte[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }

        public string Encrypt(string plainText)
        {
            plainText = plainText.ToUpper();
            byte[] plainTextData = Encoding.ASCII.GetBytes(plainText);
            string result = "";
            for (int i = 0; i < plainTextData.Length; i++)
            {
                if (plainTextData[i] < 65 || plainTextData[i] > 90)
                {
                    // add to result string if the character is not an alphabet element
                    result += Encoding.ASCII.GetString(new byte[] { plainTextData[i] });
                    continue;
                }
                // find position
                int pos = plainTextData[i] - 65;

                result += key[pos];
            }
            return result;
        }

        public string Decrypt(string encrypted)
        {
            encrypted = encrypted.ToUpper();
            // this time, we convert to byte array just to find out the current character is alphabet element or not
            byte[] encryptedData = Encoding.ASCII.GetBytes(encrypted);
            string result = "";
            for (int i = 0; i < encryptedData.Length; i++)
            {
                if (encryptedData[i] < 65 || encryptedData[i] > 90)
                {
                    // add to result string if the character is not an alphabet element
                    result += Encoding.ASCII.GetString(new byte[] { encryptedData[i] });
                    continue;
                }
                // find position
                int pos = 0;
                for (int j = 0; j < 26; j++)
                {
                    if (encrypted[i] == key[j])
                    {
                        pos = j;
                        break;
                    }
                }

                result += Encoding.ASCII.GetString(new byte[] { (byte)(pos + 65) });
            }
            return result;
        }
    }
}
