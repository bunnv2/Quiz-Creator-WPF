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
    public partial class QuizCreator : Page
    {
        private Frame frame;

        public QuizCreator(Frame fr)
        {
            frame = fr;
            InitializeComponent();
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            frame.Content = new MainMenu(frame);
        }
    }
}
