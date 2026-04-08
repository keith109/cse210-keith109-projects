namespace Homework
{
    public class Assignment
    {
        // Atributos privados
        private string _studentName;
        private string _topic;

        // Constructor
        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        // Método para obtener el nombre (necesario para la clase WritingAssignment)
        public string GetStudentName()
        {
            return _studentName;
        }

        // Método compartido
        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }
    }
}