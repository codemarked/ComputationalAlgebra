using System;
using System.Text.RegularExpressions;

namespace AlgebraComputationala
{
    /// <summary>
    /// (#7) Fiind dat (Zn ,·) grupul resturilor modulo n în raport cu înmulțirea, calculați ordinul unui element în acest grup și listați divizorii lui zero.
    /// </summary>
    public class Modulo
    {
        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Type q to exit.");
                Console.WriteLine("Or input the value of n: ");
                string key = Console.ReadLine();
                if (key == "q")
                    return;
                int n = int.Parse(key);
                Console.WriteLine("Input the value of Z: ");
                int z = int.Parse(Console.ReadLine());
                int order = Order(n, z);
                Console.WriteLine("Order of the element " + n + " in Z" + z + " " + (order != -1 ? "is " + order : "doesn't exist"));
                List<int> zeros = Zeros(z);
                Console.WriteLine("Zero divisors:");
                foreach (int divisor in zeros)
                    Console.Write(divisor + "\t");
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        static int Order(int n, int z)
        {
            int order = 1;
            int result = n % z;
            while (result != 1)
            {
                result = (result * n) % z;
                if (++order > z)
                    return -1;
            }
            return order;
        }

        static List<int> Zeros(int modulus)
        {
            List<int> divisors = new List<int>();
            for (int i = 1; i < modulus; i++)
            {
                int gcd = Utils.Gcd(i, modulus);
                if (gcd != 1 && !divisors.Contains(gcd))
                    divisors.Add(gcd);
            }
            return divisors;
        }
    }
}
