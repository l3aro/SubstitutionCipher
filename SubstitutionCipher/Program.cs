using System;

namespace SubstitutionCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            SubstitutionCipher SubstitutionCipher = new SubstitutionCipher();

            Console.Write("Nhap chuoi can ma hoa: ");
            string plainText = Console.ReadLine();
            while (plainText == "")
            {
                Console.Write("Chuoi vua nhap khong co ki tu nao! Nhap lai: ");
                plainText = Console.ReadLine();
            }

            string encrypted = SubstitutionCipher.Encrypt(plainText);
            Console.WriteLine("Chuoi da ma hoa la: {0}", encrypted);

            string decrypted = SubstitutionCipher.Decrypt(encrypted);
            Console.WriteLine("Chuoi da giai ma la: {0}", decrypted);

            Console.ReadKey();
        }
    }
}
