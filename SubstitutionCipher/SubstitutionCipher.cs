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
    }
}
