namespace AlgebraComputationala
{
    public class Program
    {
        public static void Main(String[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select program:");
                Console.WriteLine("1. Valori Proprii (ex. 1)");
                Console.WriteLine("2. Grup Galois (ex. 2)");
                Console.WriteLine("3. Sisteme de ecuatii liniare (Gauss) (ex. 5)");
                Console.WriteLine("4. Modulo (ex. 7)");
                Console.WriteLine("5. Distanta minima (Hamming) (ex. 11)");
                try
                {
                    string type = Console.ReadLine();
                    switch (type)
                    {
                        case "1": ValoriProprii.Run(); break;// #1
                        case "2": GaloisGroup.Run(); break;// #2
                        case "3": SistemeEcLiniare.Run(); break;// #5
                        case "4": Modulo.Run(); break;// #7
                        case "5": Hamming.Run(); break;// #11
                        case "q": return;
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ": " + ex.StackTrace);
                    Console.ReadKey();
                }
            }
        }
    }
}