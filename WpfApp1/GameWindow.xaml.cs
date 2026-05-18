using System.Collections.Generic;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class GameWindow : Window
    {
        private List<Word> words;
        private int currentIndex = 0;
        private bool showingEnglish = true;

        public GameWindow(List<Word> learnedWords)
        {
            InitializeComponent();
            words = learnedWords;
            ShowWord();
        }

        private void ShowWord()
        {
            if (words.Count == 0) return;
            if (currentIndex >= words.Count) currentIndex = 0;
            Word current = words[currentIndex];
            WordTextBlock.Text = showingEnglish ? current.English : current.Ukrainian;
            TranslationTextBlock.Text = "";
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            Word current = words[currentIndex];
            TranslationTextBlock.Text = showingEnglish ? current.Ukrainian : current.English;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            showingEnglish = !showingEnglish;
            ShowWord();
        }
    }
}