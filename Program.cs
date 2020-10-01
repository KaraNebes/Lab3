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
            InputCheck(x1, x2, alfa);
            allx = CreatingAnXArray(alfa, x1, x2);
            ally = CreatingAnYArray(allx);
            int maxlengthx = FindingMaxLength(allx);
            int maxlengthy = FindingMaxLength(ally);
            if (maxlengthx > maxlengthy)
                maxlength = maxlengthx;
            else
                maxlength = maxlengthy;
            Console.WriteLine(maxlength);
            DrawingTable(allx, ally, maxlength);
            Console.ReadKey();
        }
        static void Read(out double alfa, out double x1, out double x2)
        {
            Console.WriteLine("Введите начальную координату");
            x1 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.WriteLine("Введите конечную координату");
            x2 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.WriteLine("Введите альфу");
            alfa = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
        }
        static void InputCheck(double x1, double x2, double alfa)
        {
            if ( x2 == x1 || alfa==0 || (x2 < x1 && alfa > 0) ||(x2 > x1 && alfa < 0))
            {
                Console.WriteLine("Одна ошибка и ты ошибся");
                Console.ReadKey();
                Environment.Exit(0);
            }
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
            string str=" ";
            for (int i = 0; i < all.Count; i++)
            {
                str = Convert.ToString(all[i]);
                length = str.Length;
                if (length > maxlength)
                    maxlength = length;
            }
            return maxlength;
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
            string str = Convert.ToString(x);
            int length = str.Length;
            int n = maxlength - length;
            PrintNTimes(' ', n / 2);
            
            Console.Write(x);
            PrintNTimes(' ', n / 2);
            Console.Write("|");
        }
        static void DrawingTable(List<double> allx, List<double> ally, int maxlength)
        {
            Console.Write("|");
            for (int i = 0; i < 2; i++)
            {
                PrintNTimes('-', maxlength);
                Console.Write("|");
            }
            Console.WriteLine();
            Console.Write("|");
            if (maxlength % 2 != 0)
                Console.Write(' ');
            PrintNTimes(' ', maxlength / 2-1);
            Console.Write('x');
            PrintNTimes(' ', maxlength / 2-1);
            Console.Write(" | ");
            if (maxlength % 2 != 0)
                Console.Write(' ');
            PrintNTimes(' ', maxlength / 2-1);
            Console.Write('y');
            PrintNTimes(' ', maxlength / 2-1);
            Console.WriteLine("|");
            for (int i = 0; i < 2 * maxlength+3; i++)
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
