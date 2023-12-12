using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraComputationala
{
    public class Utils
    {
        public static readonly Random random = new Random();
        public static double[] Derivate(double[] coef)
        {
            double[] deriv = new double[coef.Length - 1];
            for (int i = 0; i < deriv.Length; i++)
                deriv[i] = coef[i] * (coef.Length - i - 1);
            return deriv;
        }

        public static double Determinant(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            if (size == 1)
                return matrix[0, 0];
            else if (size == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            double det = 0;
            for (int j = 0; j < size; j++)
                det += Math.Pow(-1, j) * matrix[0, j] * Determinant(SubMatrix(matrix, 0, j));
            return det;
        }
        public static double[,] SubMatrix(double[,] matrix, int exemptRow, int exemptCol)
        {
            int size = matrix.GetLength(0);
            double[,] subMatrix = new double[size - 1, size - 1];
            int r = 0, c;
            for (int i = 0; i < size; i++)
            {
                if (i == exemptRow)
                    continue;
                c = 0;
                for (int j = 0; j < size; j++)
                {
                    if (j == exemptCol)
                        continue;
                    subMatrix[r, c] = matrix[i, j];
                    c++;
                }
                r++;
            }
            return subMatrix;
        }
        public static void Print(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i] + "\t");
            Console.WriteLine();
        }
        public static void Print(int[,] v)
        {
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                    Console.Write(v[i, j] + "\t");
                Console.WriteLine();
            }
        }
        public static void Print(double[] v)
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i] + "\t");
            Console.WriteLine();
        }
        public static void Print(double[,] v)
        {
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                    Console.Write(v[i, j] + "\t");
                Console.WriteLine();
            }
        }
        public static void PrintSystem(double[,] v)
        {
            int rows = v.GetLength(0);
            int cols = v.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j == cols - 1)
                        Console.Write("|\t");
                    Console.Write(v[i, j].ToString("0.00") + "\t");
                }
                Console.WriteLine();
            }
        }
        public static void PrintSystem(double[,] A, double[] b)
        {
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(A[i, j].ToString("0.00") + "\t");
                Console.Write("|\t" + b[i].ToString("0.00"));
                Console.WriteLine();
            }
        }
        public static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
    }
}
