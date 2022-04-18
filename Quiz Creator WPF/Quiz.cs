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


        public Quiz(List<Question> questions, string name)
        {
            Questions = questions;
            Name = name;
        }
    }
}
