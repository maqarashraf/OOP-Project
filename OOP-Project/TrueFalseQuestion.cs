using OOP_Project;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace   OOP_Project
{
    class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion() : this("", 0, true) { }

        public TrueFalseQuestion(string body, int mark, bool correctIsTrue)
            : this("True | False Question", body, mark, correctIsTrue) { }

        public TrueFalseQuestion(string header, string body, int mark, bool correctIsTrue)
            : base(header, body, mark,
                   new Answer[] { new Answer(1, "True"), new Answer(2, "False") },
                   correctIsTrue ? 1 : 2)
        { }

        public override void Display()
        {
            Console.WriteLine($"{Header}    (Mark: {Mark})");
            Console.WriteLine(Body);
            Console.WriteLine($"{AnswerList[0]}      {AnswerList[1]}");
        }
    }
}