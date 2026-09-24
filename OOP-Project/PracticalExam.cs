using OOP_Project;
using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace OOP_Project
{
    class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions, Subject subject)
            : base(time, numberOfQuestions, subject) { }
        public override void ShowExam()
        {
            Console.WriteLine("\n========== Practical Exam ==========");
            Console.WriteLine($"Subject: {Subject.SubjectName} | Time: {Time} min | Questions: {NumberOfQuestions}");

            AskQuestions();

            Console.WriteLine("\n========== Right Answers ==========");
            for (int i = 0; i < Questions.Length; i++)
            {
                Question q = Questions[i];
                Console.WriteLine($"Q{i + 1}) {q.Body}");
                Console.WriteLine($"    Right answer: {q.RightAnswer.AnswerText}");
            }
        }
    }
}
