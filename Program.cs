using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            double alfa = 0, x1 = 0, x2 = 0;
            int maxlength = 0;
            List<double> allx = new List<double>();
            List<double> ally = new List<double>();
            Read(out alfa, out x1, out x2);
            allx = CreatingAnXArray(alfa, x1, x2);
            ally = CreatingAnYArray(allx);
            int maxlengthx = FindingMaxLength(allx);
            Console.WriteLine(maxlengthx);
            int maxlengthy = FindingMaxLength(ally);
            Console.WriteLine(maxlengthy);
            if (maxlengthx > maxlengthy)
                maxlength = maxlengthx;
            else
                maxlength = maxlengthy;
            Console.WriteLine(maxlength);
            DrawingTable(allx, ally, maxlength);
            Console.ReadKey();
            //Math.Round(ally[i],3);
        }
        static void Read(out double alfa, out double x1, out double x2)
        {
            Console.WriteLine("Введите начальную координату");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите конечную координату");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите альфу");
            alfa = Convert.ToDouble(Console.ReadLine());
        }
        static List<double> CreatingAnXArray(double alfa, double x1, double x2)
        {
            List<double> allx = new List<double>();
            allx.Add(x1);
            int n = Convert.ToInt32((x2 - x1) / alfa);
            for (int i = 1; i <= n; i++)
            {
                allx.Add(x1 + (alfa * i));
            }

            return allx;
        }
        static List<double> CreatingAnYArray(List<double> allx)
        {
            List<double> ally = new List<double>();
            for (int i = 0; i < allx.Count; i++)
            {
                ally.Add(Math.Sin(allx[i]));
            }
            return ally;
        }
        static int FindingMaxLength(List<double> all)
        {
            int length = 0, maxlength = 0;
            for (int i = 0; i < all.Count; i++)
            {
                length = FindingLength(all[i]);
                if (length >= maxlength)
                    maxlength = length;
            }
            maxlength++;
            return maxlength;
        }
        static int FindingLength(double x)
        {
            int length = 0;
            if (x < 0)
                length++;
            int digitlength = GetWholeDigitCount(x);
            int fractionaldigitlength = GetFractionalDigitCount(x);
            length += digitlength + fractionaldigitlength;
            return length;
        }
        static int GetWholeDigitCount(double x)
        {
            int count = 1;
            x = Math.Abs(x);
            while ((x /= 10) >= 1)
                ++count;
            return count;
        }
        static int GetFractionalDigitCount(double x)
        {
            x = Math.Abs(x);
            int count = 0;
            while (x % 1 != 0)
            {
                ++count;
                x *= 10;
            }
            return count;
        }
        static void PrintNTimes(char a, int n)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(a);
            }
        }

        static void DrawingCell(double x, int maxlength)
        {
            int n = maxlength - FindingLength(x);
            PrintNTimes(' ', n / 2);
            if (FindingLength(x) % 2 != 0)
                PrintNTimes(' ', 1);
            Console.Write(x);
            PrintNTimes(' ', n / 2);
            Console.Write("|");
        }
        static void DrawingTable(List<double> allx, List<double> ally, int maxlength)
        {
            Console.Write("|");
            for (int i = 0; i < 2; i++)
            {
                PrintNTimes('-', maxlength+1);
                Console.Write("|");
            }
            Console.WriteLine();
            Console.Write("|");
            PrintNTimes(' ', maxlength / 2);
            Console.Write('x');
            PrintNTimes(' ', maxlength / 2);
            Console.Write(" | ");
            PrintNTimes(' ', maxlength / 2);
            Console.Write('y');
            PrintNTimes(' ', maxlength / 2);
            Console.WriteLine("|");
            for (int i = 0; i < 2 * maxlength+5; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
            for (int i = 0; i < allx.Count; i++)
            {
                Console.Write("|");
                DrawingCell(allx[i], maxlength);
                DrawingCell(ally[i], maxlength);
                Console.WriteLine( );
            }
        }
    }
}
