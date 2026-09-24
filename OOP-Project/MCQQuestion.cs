using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace OOP_Project
{
    class MCQQuestion : Question
    {
        public MCQQuestion() : this("", 0, new Answer[0], 0) { }

        public MCQQuestion(string body, int mark, Answer[] answers, int rightAnswerId)
            : this("MCQ Question", body, mark, answers, rightAnswerId) { }

        public MCQQuestion(string header, string body, int mark, Answer[] answers, int rightAnswerId)
            : base(header, body, mark, answers, rightAnswerId) { }

        public override void Display()
        {
            Console.WriteLine($"{Header}    (Mark: {Mark})");
            Console.WriteLine(Body);
            foreach (Answer a in AnswerList)
                Console.WriteLine(a);
        }
    }
}