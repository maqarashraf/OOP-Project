using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Project
{
    class Answer : ICloneable, IComparable
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer() : this(0, "") { }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }

        public object Clone()
        {
            return new Answer(AnswerId, AnswerText);
        }

        public int CompareTo(object obj)
        {
            if (obj is null) return 1;
            if (!(obj is Answer other))
                throw new ArgumentException("Object is not an Answer");
            return AnswerId.CompareTo(other.AnswerId);
        }
    }
}