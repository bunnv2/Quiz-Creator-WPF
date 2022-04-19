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
    public partial class QuizName : Page
    {
        private Frame frame;
        public QuizName(Frame fr)
        {
            frame = fr;
            InitializeComponent();
        }
        private void Create_quiz(object sender, RoutedEventArgs e)
        {
            if (quiz_name_text.Text != "")
            {
                frame.Content = new QuizCreator(frame);
                Quiz quiz = new Quiz(quiz_name_text.Text);
            }
            else
            {
                MessageBox.Show("Please enter a name for the quiz");
            }
        }
    }
}
