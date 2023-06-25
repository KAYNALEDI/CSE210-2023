using System;

namespace Learning04
{
    class Program
    {
        static void Main(string[] args)
        {
            MathAssignment mathAssignment = new MathAssignment("Samuel Bennett", "Multiplication", "7.3", "3-10, 20-21");
            WritingAssignment writingAssignment = new WritingAssignment("Roberto Rodriguez", "Fractions", "The Causes of World War II");

            Console.WriteLine(mathAssignment.GetSummary());
            Console.WriteLine(mathAssignment.GetHomeworkList());

            Console.WriteLine();

            Console.WriteLine(writingAssignment.GetSummary());
            Console.WriteLine(writingAssignment.GetWritingInformation());
        }
    }

    // Base Assignment class
    class Assignment
    {
        private string _studentName;
        private string _topic;

        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }
    }

    // MathAssignment class derived from Assignment
    class MathAssignment : Assignment
    {
        private string _textbookSection;
        private string _problems;

        public MathAssignment(string studentName, string topic, string textbookSection, string problems)
            : base(studentName, topic)
        {
            _textbookSection = textbookSection;
            _problems = problems;
        }

        public string GetHomeworkList()
        {
            return $"Section {_textbookSection} Problems {_problems}";
        }
    }

    // WritingAssignment class derived from Assignment
    class WritingAssignment : Assignment
    {
        private string _title;

        public WritingAssignment(string studentName, string topic, string title)
            : base(studentName, topic)
        {
            _title = title;
        }

        public string GetWritingInformation()
        {
            return $"{_title} by {GetStudentName()}";
        }

        public string GetStudentName()
        {
            return GetSummary().Substring(0, GetSummary().IndexOf(" -"));
        }
    }
}
