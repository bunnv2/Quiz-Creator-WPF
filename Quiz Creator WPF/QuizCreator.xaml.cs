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

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            frame.Content = new MainMenu(frame);
        }

        private void Add_Question(object sender, RoutedEventArgs e)
        {
            string question = question_text.Text.ToString();
            string answer1 = answer1_text.Text.ToString();
            string answer2 = answer2_text.Text.ToString();
            string answer3 = answer3_text.Text.ToString();
            string answer4 = answer4_text.Text.ToString();
            List<bool> correct_answers = new List<bool>();
            correct_answers.Add(is_correct1.IsChecked.Value);
            correct_answers.Add(is_correct2.IsChecked.Value);
            correct_answers.Add(is_correct3.IsChecked.Value);
            correct_answers.Add(is_correct4.IsChecked.Value);

        }
    }
}
