namespace Homework
{
    public class WritingAssignment : Assignment
    {
        private string _title;

        public WritingAssignment(string studentName, string topic, string title)
            : base(studentName, topic)
        {
            _title = title;
        }

        public string GetWritingInformation()
        {
            // Usamos GetStudentName() porque _studentName es privado en la clase base
            string studentName = GetStudentName();
            return $"{_title} by {studentName}";
        }
    }
}