using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ComplexAmpDots
{
    public class Dot
    {
        public Dot(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }
        private double x;
        private double y;
    }

    public class ComplexNumber
    {
        public ComplexNumber(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        private int x;
        private int y;
    }
    public class Test
    {
        public static Dot center(Dot d1, Dot d2)
        {
            Dot _center = new Dot((d1.GetX() + d2.GetX()) / 2, (d1.GetY() + d2.GetY()) / 2);
            return _center;
        }
        public static ComplexNumber ComplexSum(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.GetX() + n2.GetX(), n1.GetY() + n2.GetY());
        }
        public static ComplexNumber ComplexDiff(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.GetX() - n2.GetX(), n1.GetY() - n2.GetY());
        }
        public static ComplexNumber ComplexComp(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.GetX() * n2.GetX() - n1.GetY() * n2.GetY(), n1.GetY() * n2.GetY() + n2.GetX() * n1.GetX());
        }
        public static void WriteComplex(ComplexNumber cn)
        {
            if (cn.GetY() > 0)
                Console.WriteLine(cn.GetX().ToString() + " + " + cn.GetY().ToString() + "i");
            else
                Console.WriteLine(cn.GetX().ToString() + " - " + (-cn.GetY()).ToString() + "i");
        }
        public static void Main()
        {
            List<Dot> axis = new List<Dot>();
            for (int i = 0; i != 3; i++)
            {
                string[] ss = Console.ReadLine().Split();
                Dot newDot = new Dot(Convert.ToDouble(ss[0]), Convert.ToDouble(ss[1]));
                axis.Add(newDot);
            }
            List<Dot> centers = new List<Dot>();
            centers.Add(center(axis[0], axis[1]));
            centers.Add(center(axis[0], axis[2]));
            centers.Add(center(axis[1], axis[2]));
            Console.ReadLine();
            List<ComplexNumber> CN = new List<ComplexNumber>();
            for (int i = 0; i != 3; i++)
            {
                string[] ss = Console.ReadLine().Split();
                ComplexNumber newCN = new ComplexNumber(Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]));
                CN.Add(newCN);
            }
            foreach (Dot d in centers)
            {
                Console.WriteLine(d.GetX().ToString() + " " + d.GetY().ToString());
            }
            Console.WriteLine();
            WriteComplex(ComplexComp(CN[0], CN[1]));
            WriteComplex(ComplexSum(CN[1], CN[2]));
            WriteComplex(ComplexDiff(CN[1], CN[2]));
            try
            {
                string link = "https://ru.wikipedia.org/wiki/%D0%91%D0%B0%D0%BB%D0%B4%D0%B0";
                WebClient webClient = new WebClient();
                webClient.DownloadFile(link, "Balda.html");
                Console.WriteLine("File successfully downloaded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("You're not doing fine ya know. Check your link representation: tou could make a mistake!");
            }
            Console.ReadLine();
        }
    }
}
