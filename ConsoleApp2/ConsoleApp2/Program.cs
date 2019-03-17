using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ScrollFiftyButtons
{
    class ScrollFiftyButtons : Window
    {
        [STAThread] public static void Main()
        {
            Application app = new Application();
            app.Run(new ScrollFiftyButtons());
        }
        public ScrollFiftyButtons()
        {
            Title = "Scroll Fifty Buttons"; //объявляет и присваивает заголовок 
            SizeToContent = SizeToContent.Width; //изменение ширины окна по содержимому
            AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonOnClick)); //проверка 
            ScrollViewer scroll = new ScrollViewer();//объявление прокрутки в недоступные области 
            Content = scroll; //добавить прокрутку 
            StackPanel stack = new StackPanel(); //выравнивание дочерних элементов в одну линию
            stack.Margin = new Thickness(5);// расстояние между объектами 
            scroll.Content = stack; 
            for (int i = 0; i < 50; i++) //создание 50 кнопок с надписью Button 'номер' says 'Click me'
            { 
                Button btn = new Button(); 
                btn.Name = "Button" + (i + 1); 
                btn.Content = btn.Name + " says  'Click me'"; 
                btn.Margin = new Thickness(5); 
                stack.Children.Add(btn); 
            } 
        } 
        void ButtonOnClick(object sender, RoutedEventArgs args) //вызов события при нажатии кнопки 
        { 
        Button btn = args.Source as Button; 
        if (btn != null) 
        MessageBox.Show(btn.Name + " has  been clicked", "Button Click"); 
        } 
    }    
}
