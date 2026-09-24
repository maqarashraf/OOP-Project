using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace OOP_Project
{
    class Subject : ICloneable, IComparable
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }  
        public Subject() : this(0, "") { }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {
            Console.WriteLine($"Creating exam for subject: {SubjectName}\n");

            int type = InputHelper.ReadInt("Exam type (1 = Final, 2 = Practical): ", 1, 2);
            int time = InputHelper.ReadInt("Exam time in minutes: ", 1, 600);
            int count = InputHelper.ReadInt("Number of questions: ", 1, 100);

            if (type == 1)
                Exam = new FinalExam(time, count, this);
            else
                Exam = new PracticalExam(time, count, this);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n--- Question {i + 1} ---");

                int questionType = 2;
                if (type == 1)
                    questionType = InputHelper.ReadInt("Question type (1 = True/False, 2 = MCQ): ", 1, 2);

                if (questionType == 1)
                    Exam.Questions[i] = ReadTrueFalseQuestion();
                else
                    Exam.Questions[i] = ReadMcqQuestion();
            }
        }

        private Question ReadTrueFalseQuestion()
        {
            string body = InputHelper.ReadString("Question body: ");
            int mark = InputHelper.ReadInt("Mark: ", 1, 100);
            int right = InputHelper.ReadInt("Right answer (1 = True, 2 = False): ", 1, 2);

            return new TrueFalseQuestion(body, mark, right == 1);
        }

        private Question ReadMcqQuestion()
        {
            string body = InputHelper.ReadString("Question body: ");
            int mark = InputHelper.ReadInt("Mark: ", 1, 100);
            int choices = InputHelper.ReadInt("Number of choices (2-6): ", 2, 6);

            Answer[] answers = new Answer[choices];
            for (int i = 0; i < choices; i++)
            {
                string text = InputHelper.ReadString($"Choice {i + 1}: ");
                answers[i] = new Answer(i + 1, text);
            }

            int right = InputHelper.ReadInt("Right answer number: ", 1, choices);

            return new MCQQuestion(body, mark, answers, right);
        }

        public override string ToString()
        {
            return $"Subject {SubjectId}: {SubjectName}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            if (obj is null) return 1;
            if (!(obj is Subject other))
                throw new ArgumentException("Object is not a Subject");
            return SubjectId.CompareTo(other.SubjectId);
        }
    }
}
