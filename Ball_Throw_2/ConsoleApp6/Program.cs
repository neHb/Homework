using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ConsoleApp9
{
    public class win : Window
    {
        TextBox txtangle;
        TextBox txtU;
        TextBox txtCoord;
        Canvas canv = new Canvas();
        Line myLine;
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            Window win = new Window();
            win.Title = "График";
            app.Run(new win());
        }

        public win()
        {

            StackPanel stackv = new StackPanel();
            Content = stackv;
            stackv.Margin = new Thickness(10);
            canv.Width = 1024;
            canv.Height = 420;
            canv.LayoutTransform = new ScaleTransform() { ScaleX = 1, ScaleY = -1 };
            stackv.Children.Add(canv);
            StackPanel stackh = new StackPanel();
            stackh.Orientation = 0;
            stackv.Children.Add(stackh);
            Label lbl = new Label();
            lbl.Content = "Угол: ";
            txtangle = new TextBox();
            txtangle.TextChanged += TextCalculate;
            stackh.Children.Add(lbl);
            stackh.Children.Add(txtangle);
            lbl = new Label();
            lbl.Content = "Скорость: ";
            txtU = new TextBox();
            txtU.TextChanged += TextCalculate;
            stackh.Children.Add(lbl);
            stackh.Children.Add(txtU);
            lbl = new Label();
            lbl.Content = "Координаты: ";
            txtCoord = new TextBox();
            txtCoord.TextChanged += TextCalculate;
            stackh.Children.Add(lbl);
            stackh.Children.Add(txtCoord);
            stackh.Width = 1000.0;
        }
        void TextCalculate(object sender, TextChangedEventArgs args)
        {

            double U0, a, x0;
            if (double.TryParse(txtangle.Text, out a) &&
                double.TryParse(txtCoord.Text, out x0) && double.TryParse(txtU.Text, out U0))
            {
                a = a * 3.14 / 180;
                double dt = 0.01;
                double tp = 2 * U0 * Math.Sin(a) / 9.8;
                Console.WriteLine($"Время полёта {tp}");
                double xp = x0;
                double yp = 0;
                for (double t = 0; t <= tp; t += dt)
                {
                    myLine = new Line();
                    myLine.X1 = xp;
                    myLine.Y1 = yp;
                    myLine.X2 = x0 + U0 * Math.Cos(a) * t;
                    myLine.Y2 = U0 * Math.Sin(a) * t - (9.8 * t * t / 2);
                    Console.WriteLine($"Позиция x: {xp}, Позиция y:{yp}, Время полёта: {tp}");
                    xp = myLine.X2;
                    yp = myLine.Y2;
                    myLine.Stroke = Brushes.Black;
                    canv.Children.Add(myLine);
                }
            }
        }


    }
}
