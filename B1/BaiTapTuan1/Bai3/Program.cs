namespace Bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            char[] options = new char[] { 'a', 'b' };
            char s;
            do
            {
                Console.WriteLine("*=========[MENU]=========*");
                Console.WriteLine("Choose to caculate: ");
                Console.WriteLine("a. Equation: ax+b=0\nb. Equation: ax^2+bx+c=0");
                Console.WriteLine("*=========[END]==========*");
                Console.Write("Select One: ");
                s = char.Parse(Console.ReadLine());
                int i = Array.IndexOf(options, s);
                if (i == -1)
                {
                    Console.WriteLine("Invalid selection!");
                    Environment.Exit(0);
                }
                Console.Write("Enter the value of 'a': ");
                a = int.Parse(Console.ReadLine());
                Console.Write("Enter the value of 'b': ");
                b = int.Parse(Console.ReadLine());
                if (i == 0)
                {
                    Console.WriteLine((a == 0) ? resultLevelOne(a, b) : ($"Result of Equation {a}x+{b}=0 is: " + resultLevelOne(a, b).ToString("F2")));
                }
                else
                {
                    Console.Write("Enter the value of 'c': ");
                    int c = int.Parse(Console.ReadLine());
                    if (a == 0)
                    {
                        Console.WriteLine((b == 0) ? resultLevelOne(b, c) : ($"Result of Equation {b}x+{c}=0 is: " + resultLevelOne(b, c).ToString("F2")));
                        continue;
                    }
                    double[] res = resultLevelTwo(a, b, c);
                    int count = res.Length;
                    if (count != 0)
                    {
                        Console.WriteLine("The solution to the equation is " + (count == 1 ? res[0] : (res[0] + " and " + res[1])));
                    }

                }


            } while (Array.IndexOf(options, s) != -1);

        }

        static double resultLevelOne(double a, double b)
        {
            if (a == 0)
            {
                Console.Write("The equation has no solution because value of 'a' invalid...");
                return 0;
            }
            return (-1 * b / a);
        }

        static double[] resultLevelTwo(int a, int b, int c)
        {
            int n;
            double delta = Math.Pow(b, 2) - 4 * a * c;
            n = (delta == 0) ? 1 : ((delta > 0) ? 2 : 0);
            if (delta == 0)
            {
                return new double[] { (-1 * b + Math.Sqrt(delta)) / (2 * a) };
            }
            else if (n > 0)
            {
                return new double[] { (-1 * b + Math.Sqrt(delta)) / (2 * a), (-1 * b - Math.Sqrt(delta)) / (2 * a) };
            }
            else
            {
                return new double[] { };
            }

        }
    }
}
