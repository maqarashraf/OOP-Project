using OOP_Project;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OOP_Project
    abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject Subject { get; set; }     
        public Question[] Questions { get; set; }

        protected Exam(int time, int numberOfQuestions, Subject subject)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Subject = subject;
            Questions = new Question[numberOfQuestions];
        }

        public abstract void ShowExam();

        public int TotalMark
        {
            get
            {
                int total = 0;
                foreach (Question q in Questions)
                    total += q.Mark;
                return total;
            }
        }

        protected void AskQuestions()
        {
            Stopwatch timer = Stopwatch.StartNew();

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1} of {Questions.Length}");
                Questions[i].Display();
                Questions[i].UserAnswerId =
                    InputHelper.ReadInt("Your answer: ", 1, Questions[i].AnswerList.Length);
            }

            timer.Stop();
            if (timer.Elapsed.TotalMinutes > Time)
                Console.WriteLine($"\nTime is over! (allowed: {Time} min)");
        }

        public override string ToString()
        {
            return $"{GetType().Name} - Subject: {Subject.SubjectName}, Time: {Time} min, Questions: {NumberOfQuestions}";
        }
    }
}