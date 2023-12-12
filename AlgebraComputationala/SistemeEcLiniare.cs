using System.Text;

namespace AlgebraComputationala
{
    /// <summary>
    /// (5) Rezolvați un sistem liniar de 4 ecuații cu 4 necunoscute prin metoda lui Gauss.
    /// </summary>
    public class SistemeEcLiniare
    {
        public static void Run()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.WriteLine("Type q to exit");
                Console.WriteLine("Type s if you want to execute for saved matrix");
                Console.WriteLine("Type r if you want to execute for a random matrix");
                Console.WriteLine("Or insert rows split by a space ' '");
                string key = Console.ReadLine();
                if (key == "q")
                    return;
                Console.WriteLine();
                double[,] A = { 
                    { 3, 1, 4, 0 },
                    { 1, 1, -3, 1 },
                    { 1, 0, 1, 0 },
                    { 0, 1, 0, -1 }
                };
                double[] b = { 1, 6, 0, 2 };
                if (key == "r")
                {
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                            A[i, j] = Utils.random.Next(10) + 1 * (Utils.random.Next(2) > 0 ? 1 : -1);
                    for (int j = 0; j < 4; j++)
                        b[j] = Utils.random.Next(10) + 1 * (Utils.random.Next(2) > 0 ? 1 : -1);
                } else if (key != "s")
                {
                    List<string> strings = new List<string>();
                    strings.Add(key);
                    string buffer;
                    while ((buffer = Console.ReadLine()) != null)
                        strings.Add(buffer);
                    string[] row = strings[0].Split(' ');
                    A = new double[strings.Count, row.Length - 1];
                    for (int i = 0; i < strings.Count; i++)
                    {
                        row = strings[i].Split(' ');
                        for (int j = 0; j < row.Length; j++)
                            if (j == row.Length - 1)
                                b[i] = int.Parse(row[j]);
                            else
                                A[i, j] = int.Parse(row[j]);
                    }
                }
                Console.WriteLine("Coefficient matrix:");
                Console.WriteLine();
                Utils.PrintSystem(A, b);
                Console.WriteLine();
                double[] sol = Gauss2(A, b);
                Utils.PrintSystem(A, b);
                Console.WriteLine();
                Console.WriteLine("x:");
                for (int i = 0; i < sol.Length; i++)
                    Console.WriteLine($"x[{i}] = {sol[i].ToString("0.00")}");
                Console.ReadKey();
            }
        }
        static double[] Gauss2(double[,] A, double[] b)
        {
            int n = b.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                double maxVal = Math.Abs(A[i, i]);
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(A[k, i]) > Math.Abs(maxVal))
                    {
                        maxVal = Math.Abs(A[k, i]);
                        maxIndex = k;
                    }
                }
                if (maxIndex != i)
                {
                    for (int j = i; j < n; j++)
                    {
                        double temp = A[i, j];
                        A[i, j] = A[maxIndex, j];
                        A[maxIndex, j] = temp;
                    }
                    double tempConstant = b[i];
                    b[i] = b[maxIndex];
                    b[maxIndex] = tempConstant;
                }
                for (int j = i + 1; j < n; j++)
                {
                    double factor = A[j, i] / A[i, i];
                    for (int k = i; k < n; k++)
                        A[j, k] -= factor * A[i, k];
                    b[j] -= factor * b[i];
                }
            }
            double[] sol = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < n; j++)
                    sum += A[i, j] * sol[j];
                sol[i] = (b[i] - sum) / A[i, i];
            }
            return sol;
        }
        static void Gauss(double[,] coefficients)
        {
            int rows = coefficients.GetLength(0);
            int cols = coefficients.GetLength(1);
            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = i + 1; k < rows; k++)
                {
                    double factor = coefficients[k, i] / coefficients[i, i];
                    for (int j = i; j < cols - 1; j++)
                        coefficients[k, j] -= factor * coefficients[i, j];
                }
            }
            for (int i = rows - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < cols - 1; j++)
                    sum += coefficients[i, j] * coefficients[j, cols - 1];
                coefficients[i, cols - 1] = (coefficients[i, cols - 1] - sum) / coefficients[i, i];
            }
        }
    }
}
