using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Creator_WPF
{
    internal class Quiz
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }


        public Quiz(string name)
        {
            Name = name;
            Questions = new List<Question>();
        }
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }
    }
}
