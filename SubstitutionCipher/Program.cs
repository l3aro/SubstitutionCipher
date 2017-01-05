using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstitutionCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            SubstitutionCipher SubstitutionCipher = new SubstitutionCipher();

            string encrypted = SubstitutionCipher.Encrypt("Vu Thu Hoai");

            string decrypted = SubstitutionCipher.Decrypt(encrypted);

            Console.ReadKey();
        }
    }
}
