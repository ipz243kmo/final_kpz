namespace WpfApp1.Models
{
    public class ReadingExercise
    {
        public string TextEnglish { get; set; }           
        public string TextUkrainian { get; set; }        
        public string[] EnglishToUkrainianOptions { get; set; } 
        public string[] UkrainianToEnglishOptions { get; set; }
        public string[] CorrectEnglishToUkrainian { get; set; } 
        public string[] CorrectUkrainianToEnglish { get; set; } 
        public string Explanation { get; set; }          
        public string Question { get; set; }         
        public string[] QuestionOptions { get; set; }    
        public string CorrectQuestionAnswer { get; set; } 
}