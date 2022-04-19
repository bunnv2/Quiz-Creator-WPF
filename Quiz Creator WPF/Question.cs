using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Creator_WPF
{
    internal class Question
    {
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
        public Question(string name)
        {
            QuestionText = name;
            Answers = new List<Answer>();
        }

        public void AddAnswer(Answer answer)
        {
            Answers.Add(answer);
        }

        public override string ToString()
        {
            return QuestionText;
        }
    }
}