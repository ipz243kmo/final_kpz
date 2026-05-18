namespace WpfApp1.Models
{
    public class GrammarExercise
    {
        public string SentenceTemplate { get; set; } = "";
        public string[] CorrectWords { get; set; } = new string[0];
        public string[] Options { get; set; } = new string[0];
        public string Explanation { get; set; } = "";
    }
}