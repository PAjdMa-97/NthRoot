using System;

namespace NthRoot // Note: actual namespace depends on the project name.
{
    internal class NthRootApp
    {
        static void Main(string[] args)
        {
            double result = MathExtension.GetNthRoot(490713.154, 6);
            Console.WriteLine(result);
        }
    }

    public static class MathExtension
    {
        public static double GetNthRoot(double number, int n)
        {
            if (number < 1)
                throw new ArgumentException();

            // choose a first value to approximate nthroot
            double x = 1.0, cmp = 1.0;

            // Define the math serie wich will evaluate nth root
            Func<int, double, double, double> serie = (n, x, number) => (1 / (double)n) * ((n - 1) * x + (number / x.Pow(n - 1)));

            int i = 0;

            // execute serie until it converge
            do
            {
                cmp = x;
                x = serie(n, x, number);
                ++i;
            } while (cmp != x);
            Console.WriteLine(i);

            return x;
        }

        public static double Pow(this double number, int n)
        {
            double result = 1.0;

            for (int i = 0; i < n; i++, result *= number);

            return result;
        }
    }
}