using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public Frame frame;
        private Quiz quiz;
        private int currentQuestionIndex;

        public QuizCreator(Frame fr, string name)
        {
            frame = fr;
            if (name.Contains(".txt"))
            {
                string path = name;
                string lines = Decrypt_file(path);


                string[] linesArray = lines.Split('\n');
                string quizName = linesArray[0];
                quiz = new Quiz(quizName);

                for (int i = 1; i < linesArray.Length; i += 5)
                {
                    Question question = new Question(linesArray[i].Trim());
                    for (int j = i + 1; j < i + 5; j++)
                    {
                        if (j >= linesArray.Length)
                        {
                            break;
                        }
                        string[] temp = linesArray[j].Split(':');
                        Answer answer = new Answer(question, temp[0], temp[1].Contains("True"));
                        question.AddAnswer(answer);
                    }
                    quiz.AddQuestion(question);
                }
                InitializeComponent();
                UpdateQuestions();
            }
            else
            {
                quiz = new Quiz(name);
                InitializeComponent();
            }
        }
        private void UpdateQuestions()
        {
            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = quiz.Questions[i];
                item.MouseDoubleClick += ListBoxItem_Selected;
                questions_listbox.Items.Add(item);
                currentQuestionIndex = i;
            }
            question_text.Text = quiz.Questions[0].QuestionText;
            answer1_text.Text = quiz.Questions[0].Answers[0].Text;
            answer2_text.Text = quiz.Questions[0].Answers[1].Text;
            answer3_text.Text = quiz.Questions[0].Answers[2].Text;
            answer4_text.Text = quiz.Questions[0].Answers[3].Text;
            is_correct1.IsChecked = quiz.Questions[0].Answers[0].IsCorrect;
            is_correct2.IsChecked = quiz.Questions[0].Answers[1].IsCorrect;
            is_correct3.IsChecked = quiz.Questions[0].Answers[2].IsCorrect;
            is_correct4.IsChecked = quiz.Questions[0].Answers[3].IsCorrect;
            questions_listbox.SelectedIndex = 0;
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

            if (question == "" || answer1 == "" || answer2 == "" || answer3 == "" || answer4 == "")
            {
                MessageBox.Show("You must fill in all fields");
                return;
            }
            if (is_correct1.IsChecked == false && is_correct2.IsChecked == false && is_correct3.IsChecked == false && is_correct4.IsChecked == false)
            {
                MessageBox.Show("Please select at least one correct answer");
                return;
            }

            Question q = new Question(question);
            Answer a1 = new Answer(q, answer1, is_correct1.IsChecked.Value);
            Answer a2 = new Answer(q, answer2, is_correct2.IsChecked.Value);
            Answer a3 = new Answer(q, answer3, is_correct3.IsChecked.Value);
            Answer a4 = new Answer(q, answer4, is_correct4.IsChecked.Value);

            q.AddAnswer(a1);
            q.AddAnswer(a2);
            q.AddAnswer(a3);
            q.AddAnswer(a4);
            quiz.AddQuestion(q);

            question_text.Text = "";
            answer1_text.Text = "";
            answer2_text.Text = "";
            answer3_text.Text = "";
            answer4_text.Text = "";
            is_correct1.IsChecked = false;
            is_correct2.IsChecked = false;
            is_correct3.IsChecked = false;
            is_correct4.IsChecked = false;

            ListBoxItem item = new ListBoxItem();
            item.Content = q;
            item.MouseDoubleClick += ListBoxItem_Selected;
            questions_listbox.Items.Add(item);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)sender;
            Question q = (Question)item.Content;
            question_text.Text = q.QuestionText;
            answer1_text.Text = q.Answers[0].Text;
            answer2_text.Text = q.Answers[1].Text;
            answer3_text.Text = q.Answers[2].Text;
            answer4_text.Text = q.Answers[3].Text;
            is_correct1.IsChecked = q.Answers[0].IsCorrect;
            is_correct2.IsChecked = q.Answers[1].IsCorrect;
            is_correct3.IsChecked = q.Answers[2].IsCorrect;
            is_correct4.IsChecked = q.Answers[3].IsCorrect;

            currentQuestionIndex = questions_listbox.Items.IndexOf(item);
            item.IsSelected = false;
        }

        private void Modify_question(object sender, RoutedEventArgs e)
        {

            string question = question_text.Text.ToString();
            string answer1 = answer1_text.Text.ToString();
            string answer2 = answer2_text.Text.ToString();
            string answer3 = answer3_text.Text.ToString();
            string answer4 = answer4_text.Text.ToString();

            if (question == "" || answer1 == "" || answer2 == "" || answer3 == "" || answer4 == "")
            {
                MessageBox.Show("You must fill in all fields");
                return;
            }
            if (is_correct1.IsChecked == false && is_correct2.IsChecked == false && is_correct3.IsChecked == false && is_correct4.IsChecked == false)
            {
                MessageBox.Show("Please select at least one correct answer");
                return;
            }

            questions_listbox.Items.RemoveAt(currentQuestionIndex);

            Question q = new Question(question);
            Answer a1 = new Answer(q, answer1, is_correct1.IsChecked.Value);
            Answer a2 = new Answer(q, answer2, is_correct2.IsChecked.Value);
            Answer a3 = new Answer(q, answer3, is_correct3.IsChecked.Value);
            Answer a4 = new Answer(q, answer4, is_correct4.IsChecked.Value);

            q.AddAnswer(a1);
            q.AddAnswer(a2);
            q.AddAnswer(a3);
            q.AddAnswer(a4);
            quiz.AddQuestion(q);

            question_text.Text = "";
            answer1_text.Text = "";
            answer2_text.Text = "";
            answer3_text.Text = "";
            answer4_text.Text = "";
            is_correct1.IsChecked = false;
            is_correct2.IsChecked = false;
            is_correct3.IsChecked = false;
            is_correct4.IsChecked = false;

            ListBoxItem item = new ListBoxItem();
            item.Content = q;
            item.MouseDoubleClick += ListBoxItem_Selected;
            questions_listbox.Items.Add(item);

        }

        private void Delete_question(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex = questions_listbox.SelectedIndex;
            if (currentQuestionIndex == -1)
            {
                MessageBox.Show("You must select a question to delete");
                return;
            }
            ListBoxItem item = (ListBoxItem)questions_listbox.Items[currentQuestionIndex];
            questions_listbox.Items.RemoveAt(currentQuestionIndex);
            Question q = (Question)item.Content;
            quiz.RemoveQuestion(q);

            question_text.Text = "";
            answer1_text.Text = "";
            answer2_text.Text = "";
            answer3_text.Text = "";
            answer4_text.Text = "";
            is_correct1.IsChecked = false;
            is_correct2.IsChecked = false;
            is_correct3.IsChecked = false;
            is_correct4.IsChecked = false;
        }

        private void Export_quiz(object sender, RoutedEventArgs e)
        {
            if (quiz.Questions.Count == 0)
            {
                MessageBox.Show("You must add at least one question");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Quiz files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (saveFileDialog.ShowDialog() == true)
            {
                //save to text file all questions and answers
                string fileName = saveFileDialog.FileName;

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.Write("");
                    sw.WriteLine(quiz.Name);
                    foreach (Question q in quiz.Questions)
                    {
                        sw.WriteLine(q.QuestionText);
                        foreach (Answer a in q.Answers)
                        {
                            sw.WriteLine(a.Text + ":" + a.IsCorrect);
                        }
                    }
                }
                Encrypt_file(fileName);
            }
        }

        private void Encrypt_file(string filepath)
        {
            string file_content = File.ReadAllText(filepath);
            string encrypted_file_content = Encryption.Encrypt(file_content);
            File.WriteAllText(filepath, encrypted_file_content);
        }
        private string Decrypt_file(string filepath)
        {
            string file_content = File.ReadAllText(filepath);
            return Encryption.Decrypt(file_content);
        }
    }
}
