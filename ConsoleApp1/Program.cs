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
        public double m = 0;
        public double k = 0;
        public void Motion_Path(ref List<Coordinates> coordinates)
        {
            double xpos_p = 0;
            double ypos_p = 0;
            double Ux_p = U0 * Math.Cos(a * Math.PI / 180);
            double Uy_p = U0 * Math.Sin(a * Math.PI / 180);
            double Ux = 0;
            double Uy = 0;
            a = a * 3.14 / 180;
            while (ypos_p >= 0)
            {
                Coordinates NewCoor = new Coordinates();
                NewCoor.xpos = xpos_p + Ux_p * dt;
                NewCoor.ypos = ypos_p + Uy_p * dt;
                Ux = Ux_p * (1 - k / m * dt);
                Uy = Uy_p - dt * (9.8 + k / m * Uy_p);
                xpos_p = NewCoor.xpos;
                ypos_p = NewCoor.ypos;
                Ux_p = Ux;
                Uy_p = Uy;
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
            Motion.k = Convert.ToDouble(sr.ReadLine());
            Motion.m = Convert.ToDouble(sr.ReadLine());
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
