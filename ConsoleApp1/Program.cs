using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Coordinates
    {
        public double xpos = 0;
        public double ypos = 0;
    }
    class Law_Of_Motion
    {
        public double x0 = 0;
        public double a = 0;
        public double U0 = 0;
        public double dt = 0;  
        public void Motion_Path(ref List<Coordinates> coordinates)
        {
            
            double tp = 2 * U0 * Math.Sin(a) / 9.8; 
            a = a * 3.14 / 180;
            for (double t = 0; t <= tp; t += dt)
            {
                Coordinates NewCoor = new Coordinates();
                NewCoor.xpos = x0 + U0 * Math.Cos(a) * t;
                NewCoor.ypos = U0 * Math.Sin(a) * t - (9.8 * t * t / 2);
                coordinates.Add(NewCoor);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Coordinates> coordinates = new List<Coordinates>();
            Law_Of_Motion Motion = new Law_Of_Motion();
            string link1 = @"D:\text.txt";
            string link2 = @"D:\text2.txt";
            StreamReader sr = new StreamReader(link1);
            Motion.x0 = Convert.ToDouble(sr.ReadLine());
            Motion.a = Convert.ToDouble(sr.ReadLine());
            Motion.U0 = Convert.ToDouble(sr.ReadLine());
            Motion.dt = Convert.ToDouble(sr.ReadLine());
            sr.Close();
            Motion.Motion_Path(ref coordinates);
            StreamWriter sw = new StreamWriter(link2);
            foreach (Coordinates k in coordinates)
                sw.WriteLine($"Позиция x: {k.xpos}, Позиция y:{k.ypos}");
            sw.Close();
            Console.ReadKey();
        }
    }
}   
