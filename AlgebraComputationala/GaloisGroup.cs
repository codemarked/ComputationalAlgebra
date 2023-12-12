namespace AlgebraComputationala
{
    /// <summary>
    /// (Obligatoriu #2) Determinați grupul Galois asociat unui polinom de gradul 3 sau 4.
    /// </summary>
    public class GaloisGroup
    {
        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Type q to exit.");
                Console.WriteLine("Type s to execute for saved coefficients.");
                Console.WriteLine("Or input the polynomial coefficients:");
                string input = Console.ReadLine();
                if (input == "q")
                    return;
                if (input == "s")
                    input = "1 1 -2 -1";
                string[] split = input.Split(' ');
                double[] coef = new double[split.Length];
                int a = 0;
                foreach (string str in split)
                    coef[a++] = double.Parse(str);
                Console.WriteLine("Coefficients:");
                Utils.Print(coef);
                double[] deriv = Utils.Derivate(coef);
                Console.WriteLine("Derivates:");
                Utils.Print(deriv);
                double[,] res = Galois(coef, deriv);
                Console.WriteLine("Result:");
                Utils.Print(res);
                double det = Utils.Determinant(res);
                Console.WriteLine("Determinant: " + det);
                int coefOrdin = coef.Length - 1;
                double P65 = Math.Pow(-1, coefOrdin * (coefOrdin - 1) / 2) * coef[0] * det;
                Console.WriteLine($"Din Prop. 65 => Det: {P65}");
                Console.WriteLine((!PP(P65) ? "NU " : "") + "este patrat perfect!");
                Console.ReadKey();
            }
        }

        static double[,] Galois(double[] coef, double[] deriv)
        {
            int coefOrdin = coef.Length - 1;
            int derivOrdin = deriv.Length - 1;
            double[,] res = new double[coefOrdin + derivOrdin, coefOrdin + derivOrdin];
            for (int i = 0; i < res.GetLength(0); i++)
                for (int j = 0; j < res.GetLength(1); j++)
                    res[i, j] = 0;
            int indent = 0;
            while (indent < derivOrdin)
            {
                for (int j = 0; j < coef.Length; j++)
                    res[indent, j + indent] = coef[j];
                indent++;
            }
            indent = 0;
            while (indent < coefOrdin)
            {
                for (int j = 0; j < deriv.Length; j++)
                    res[derivOrdin + indent, j + indent] = deriv[j];
                indent++;
            }
            return res;
        }

        static bool PP(double a)
        {
            for (int i = 2; i <= Math.Sqrt(a); i++)
                if (i * i == a)
                    return true;
            return false;
        }
    }
}
