using OOP_Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Project
{
    abstract class Question : ICloneable, IComparable
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public int UserAnswerId { get; set; }
        protected Question() : this("", "", 0) { }

        protected Question(string header, string body, int mark)
            : this(header, body, mark, new Answer[0], 0) { }

        protected Question(string header, string body, int mark, Answer[] answerList, int rightAnswerId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = Array.Find(answerList, a => a.AnswerId == rightAnswerId);
        }

        public bool IsCorrect
        {
            get { return RightAnswer != null && UserAnswerId == RightAnswer.AnswerId; }
        }

        public string UserAnswerText
        {
            get
            {
                Answer chosen = Array.Find(AnswerList, a => a.AnswerId == UserAnswerId);
                return chosen != null ? chosen.AnswerText : "(no answer)";
            }
        }

        public abstract void Display();

        public override string ToString()
        {
            return $"[{Header}] {Body} (Mark: {Mark})";
        }

        public virtual object Clone()
        {
            Question copy = (Question)MemberwiseClone();

            copy.AnswerList = new Answer[AnswerList.Length];
            for (int i = 0; i < AnswerList.Length; i++)
                copy.AnswerList[i] = (Answer)AnswerList[i].Clone();

            if (RightAnswer != null)
                copy.RightAnswer = Array.Find(copy.AnswerList, a => a.AnswerId == RightAnswer.AnswerId);

            return copy;
        }

        public int CompareTo(object obj)
        {
            if (obj is null) return 1;
            if (!(obj is Question other))
                throw new ArgumentException("Object is not a Question");
            return Mark.CompareTo(other.Mark);
        }
    }
}
