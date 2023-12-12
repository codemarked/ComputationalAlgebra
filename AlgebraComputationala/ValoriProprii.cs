using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraComputationala
{
    /// <summary>
    /// (Obligatoriu #1) Calculați valorile proprii asociate unei matrici de ordinul 2 sau 3, afișând polinomul caracteristic asociat
    /// </summary>
    public class ValoriProprii
    {

        public static void Run()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.WriteLine("Type q to exit");
                Console.WriteLine("Type s to execute for a saved matrix.");
                Console.WriteLine("Type r if you want to generate a random matrix");
                Console.WriteLine("Or input the size of the matrix:");
                string key = Console.ReadLine();
                if (key == null)
                    continue;
                if (key == "q")
                    return;
                Console.WriteLine();
                double[,] m;
                int size;
                if (key == "r")
                {
                    size = Utils.random.Next(1) + 2;
                    m = new double[size, size];
                    for (int i = 0; i < size; i++)
                        for (int j = 0; j < size; j++)
                            m[i, j] = Utils.random.Next(5);
                }
                else if (key == "s")
                {
                    size = 2;
                    m = new double[size, size];
                    m[0, 0] = 2;
                    m[0, 1] = 4;
                    m[1, 0] = 4;
                    m[1, 1] = 3;
                }
                else
                {
                    size = int.Parse(key);
                    m = new double[size, size];
                    Console.WriteLine("Insert rows split by a space ' '");
                    for (int i = 0; i < size; i++)
                    {
                        string[] row = Console.ReadLine().Split(' ');
                        for (int j = 0; j < row.Length; j++)
                            m[i, j] = int.Parse(row[j]);
                    }
                }
                Console.WriteLine("Generated matrix:");
                Console.WriteLine();
                Utils.Print(m);
                Console.WriteLine();
                double mds = MDS(m, size);
                double det = Utils.Determinant(m);
                Console.WriteLine($"Det={det}");
                Console.WriteLine($"Characteristic pol: λ^2 {StringifyValue(mds)}λ {StringifyValue(det)}");
                double sqd = Math.Sqrt(mds * mds - 4 * det);
                double vp1 = (mds + sqd) / 2;
                double vp2 = (mds - sqd) / 2;
                Console.WriteLine($"VP1={vp1}");
                Console.WriteLine($"VP2={vp2}");
                Console.ReadKey();
            }
        }

        static string StringifyValue(double value)
        {
            return value < 0 ? $"- {value * -1}" : $"+ {value}";
        }

        static double MDS(double[,] m, int size)
        {
            double sum = 0;
            for (int i = 0; i < size; i++)
                sum += m[i, i];
            return sum;
        }
    }
}
