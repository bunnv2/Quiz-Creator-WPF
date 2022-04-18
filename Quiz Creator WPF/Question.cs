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

        public Question(List<Answer> answers, string name)
        {
            QuestionText = name;
            Answers = answers;
        }

    }
}