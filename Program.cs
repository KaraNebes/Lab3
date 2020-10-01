using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            double alfa=0, x1=0, x2=0, maxlength=0;
            List<double> allx = new List<double>();
            List<double> ally = new List<double>();
            Read(out alfa, out x1, out x2);
            allx = CreatingAnXArray(alfa, x1, x2);
            ally = CreatingAnYArray(allx);
            int maxlengthx = FindingMaxLength(allx);
            int maxlengthy = FindingMaxLength(ally);
            if (maxlengthx > maxlengthy)
                maxlength = maxlengthx;
            else
                maxlength = maxlengthy;
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
        static int FindingMaxLength (List<double> all)
        {
            int digitlength = 0, fractionaldigitlength = 0, length = 0, maxlength = 0;
            for(int i =0; i<all.Count; i++)
            {
                length = 0;
                if (all[i] < 0)
                    length++;
                digitlength = GetWholeDigitCount(all[i]);
                fractionaldigitlength = GetFractionalDigitCount(all[i]);
                length += digitlength + fractionaldigitlength;
                if (length >= maxlength)
                    maxlength = length;
                
            }
            return maxlength;
        }
        static int GetWholeDigitCount (double x)
        {
            int count = 1;
            x = Math.Abs(x);
            while ((x /= 10) >= 1)
                ++count;
            return count;
        }
        static int GetFractionalDigitCount(double x)
        {
            x = Math.Round(Math.Abs(x),3);
            int count = 0;
            while (x % 1 != 0)
            {
                ++count;
                x *= 10;
            }
            return count;
        }
    }
}
