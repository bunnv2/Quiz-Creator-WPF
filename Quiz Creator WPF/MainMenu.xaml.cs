using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_Creator_WPF
{
    public partial class MainMenu : Page
    {
        private Frame frame;
        public MainMenu(Frame fr)
        {
            frame = fr;
            InitializeComponent();
        }
        private void Create_click(object sender, RoutedEventArgs e)
        {
            frame.Content = new QuizCreator(frame);
        }

        private void Quizes_click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
