using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            double alfa=0, x1=0, x2=0;
            List<double> allx = new List<double>();
            List<double> ally = new List<double>();
            Read(out alfa, out x1, out x2);
            allx = CreatingAnXArray(alfa, x1, x2);
            ally = CreatingAnYArray(allx);
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
        static List<double> CreatingAnXArray (double alfa, double x1, double x2)
        {
            List<double> allx = new List<double>();
            allx.Add(x1);
            int n = Convert.ToInt32((x2 - x1) / alfa);
            for (int i=1; i <= n; i++)
            {
                allx.Add(x1 + (alfa * i));
            }
            return allx;
        }
        static List<double> CreatingAnYArray (List<double> allx)
        {
            List<double> ally = new List<double>();
            for (int i = 0; i < allx.Count; i++)
            {
                ally.Add(Math.Sin(allx[i]));

            }
            return ally;
        }
    }
}
