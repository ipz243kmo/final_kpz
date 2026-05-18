namespace WpfApp1.Models
{
    public class Word
    {
        public string English { get; set; }
        public string Transcription { get; set; }
        public string Ukrainian { get; set; }
        public string ImagePath { get; set; }
        public bool IsLearned { get; set; } = false;

        public Word(string english, string transcription, string ukrainian, string imagePath)
        {
            English = english ?? "";
            Transcription = transcription ?? "";
            Ukrainian = ukrainian ?? "";
            ImagePath = imagePath ?? "";
        }
    }
}