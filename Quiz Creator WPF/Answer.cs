using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Creator_WPF
{
    internal class Answer
    {
        public Question Question { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer(Question question, string text, bool isCorrect)
        {
            Question = question;
            Text = text;
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
