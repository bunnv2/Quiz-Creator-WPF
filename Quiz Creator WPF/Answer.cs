using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Creator_WPF
{
    internal class Answer
    {
        private Question question { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
