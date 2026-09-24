using OOP_Project;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;


namespace OOP_Project
{
    class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions, Subject subject)
            : base(time, numberOfQuestions, subject) { }
        public override void ShowExam()
        {
            Console.WriteLine("\n========== Final Exam ==========");
            Console.WriteLine($"Subject: {Subject.SubjectName} | Time: {Time} min | Questions: {NumberOfQuestions}");

            AskQuestions();

            Console.WriteLine("\n========== Final Exam Result ==========");
            int grade = 0;
            for (int i = 0; i < Questions.Length; i++)
            {
                Question q = Questions[i];
                Console.WriteLine($"Q{i + 1}) {q.Body}");
                Console.WriteLine($"    Your answer: {q.UserAnswerText}");
                if (q.IsCorrect)
                    grade += q.Mark;
            }

            Console.WriteLine($"\nGrade: {grade} / {TotalMark}");
        }
    }
}
