namespace WpfApp1.Models
{
    public class User
    {
        public string Login { get; set; } = "";
        public string Password { get; set; } = ""; 
        public string PhotoPath { get; set; } = "";
        public int Level { get; set; }        
        public int LessonsCompleted { get; set; }
        public int StudyMinutes { get; set; }
       
        public Dictionary<string, bool> GrammarProgress { get; set; } = new();

    }
}