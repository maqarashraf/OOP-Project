namespace OOP_Project
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C# & OOP");

            subject.CreateExam();    
            Console.WriteLine("\n" + subject.Exam);

            subject.Exam.ShowExam();   
        }
    }
}
