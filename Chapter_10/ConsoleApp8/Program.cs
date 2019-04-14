using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.RenderTheBetterEllipse
{
    public class BetterEllipse : FrameworkElement
    {
        // Dependency properties.  
        public static readonly DependencyProperty  FillProperty;
        public static readonly DependencyProperty  StrokeProperty;
        // Public interfaces to dependency properties.         
        public Brush Fill
        {
            set { SetValue(FillProperty, value);}
            get { return (Brush)GetValue (FillProperty); }
        }
        public Pen Stroke
        {

            set { SetValue(StrokeProperty, value); }
            get { return (Pen)GetValue (StrokeProperty); }
        }
        // Static constructor. 
        static BetterEllipse()
        {
            FillProperty =
                DependencyProperty.Register("Fill" , typeof(Brush), 
                typeof(BetterEllipse), new  FrameworkPropertyMetadata(null, 
                FrameworkPropertyMetadataOptions.AffectsRender));
            StrokeProperty =     
                DependencyProperty.Register ("Stroke", typeof(Pen),  
                typeof(BetterEllipse), new  FrameworkPropertyMetadata(null,    
                FrameworkPropertyMetadataOptions.AffectsMeasure));
        }
        // Override of MeasureOverride. 
        protected override Size MeasureOverride (Size sizeAvailable)
        {
            Size sizeDesired = base .MeasureOverride(sizeAvailable);
            if (Stroke != null)
                sizeDesired = new Size(Stroke .Thickness, Stroke.Thickness);
            return sizeDesired;
        }
        // Override of OnRender.  
        protected override void OnRender (DrawingContext dc)
        {
            Size size = RenderSize;
            // Adjust rendering size for width of Pen.  
            if (Stroke != null)
            {
                size.Width = Math.Max(0, size .Width - Stroke.Thickness);
                size.Height = Math.Max(0, size .Height - Stroke.Thickness);
            }
            // Draw the ellipse.  
            dc.DrawEllipse(Fill, Stroke,     
                new Point(RenderSize.Width / 2,  RenderSize.Height / 2),  
                size.Width / 2, size.Height / 2);
        }
    } 
        public class RenderTheBetterEllipse : Window
    {
        [STAThread] public static void Main()
        {
            Application app = new Application();
            app.Run(new RenderTheBetterEllipse());
        }
        public RenderTheBetterEllipse()
        {
            Title = "Render the Better Ellipse";
            BetterEllipse elips = new BetterEllipse();
            elips.Fill = Brushes.AliceBlue;
            elips.Stroke = new Pen(new LinearGradientBrush(Colors.CadetBlue, Colors.Chocolate, new Point(1, 0), new Point(0, 1)), 24);
            // 1/4 inch      
            Content = elips;
        }
    }
} 