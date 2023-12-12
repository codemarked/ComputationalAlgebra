using System;

namespace AlgebraComputationala
{
    /// <summary>
    /// (#11) (din Teoria codurilor) Calculați distanța minimala a unui cod dat în(Fq)n
    /// </summary>
    public class Hamming
    {
        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Type q to exit!");
                Console.WriteLine("Type s to execute for saved values!");
                Console.WriteLine("Or input code on lines:");
                string key = Console.ReadLine();
                if (key == "q")
                    return;
                List<string> strings = new List<string>();
                if (key == "s")
                {
                    strings.Add("1101");
                    strings.Add("1001");
                    strings.Add("0001");
                    strings.Add("1011");
                    strings.Add("0101");
                    strings.Add("0111");
                }
                else
                {
                    string buffer = key;
                    if (buffer != null && buffer != "")
                    {
                        strings.Add(buffer);
                        while (true)
                        {
                            buffer = Console.ReadLine();
                            if (buffer == null || buffer == "")
                                break;
                            strings.Add(buffer);
                        }
                    }
                }
                string row = strings[0];
                int[,] code = new int[strings.Count, row.Length];
                for (int j = 0; j < row.Length; j++)
                    code[0, j] = int.Parse($"{row[j]}");
                for (int i = 1; i < strings.Count; i++)
                {
                    row = strings[i];
                    for (int j = 0; j < row.Length; j++)
                        code[i, j] = int.Parse($"{row[j]}");
                }
                Console.WriteLine();
                Utils.Print(code);
                Console.WriteLine();
                Console.WriteLine();
                int distance = MinimumDistance(code);
                Console.WriteLine("Hamming distance: " + distance);
                Console.ReadKey();
            }
        }

        static int MinimumDistance(int[,] code)
        {
            int min = int.MaxValue;
            int rows = code.GetLength(0);
            int cols = code.GetLength(1);
            for (int i = 0; i < rows - 1; i++)
                for (int j = i + 1; j < rows; j++)
                {
                    int[] c1 = new int[cols];
                    int[] c2 = new int[cols];
                    for (int k = 0; k < cols; k++)
                    {
                        c1[k] = code[i, k];
                        c2[k] = code[j, k];
                    }
                    Utils.Print(c1);
                    Utils.Print(c2);
                    Console.WriteLine();
                    int dist = Distance(c1, c2);
                    if (dist < min)
                        min = dist;
                }
            return min;
        }

        static int Distance(int[] c1, int[] c2)
        {
            int distance = 0;
            for (int i = 0; i < c1.Length; i++)
                if (c1[i] != c2[i])
                    distance++;
            return distance;
        }
    }
}
