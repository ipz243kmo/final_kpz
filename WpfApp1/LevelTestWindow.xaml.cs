using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    public partial class LevelTestWindow : Window
    {
        private User currentUser;

        private readonly List<string> questions = new List<string>()
        {
            "1. Translate 'Apple' into your language.",
            "2. What does 'Good morning' mean?",
            "3. Choose the correct verb form: 'He ___ to school.'",
            "4. Translate: 'I like reading books.'",
            "5. What does 'I am happy' mean?",
            "6. Which article goes before 'orange'?",
            "7. Choose the correct word: 'She ___ swimming.'",
            "8. Translate: 'He plays football.'",
            "9. What does 'Can you help me?' mean?",
            "10. Choose the correct translation: 'I do not understand.'",
            "11. Fill in the blank: 'They ___ at home.'",
            "12. Translate: 'We are learning English.'",
            "13. Choose the correct verb form: 'I ___ a book.'",
            "14. Translate: 'It is interesting.'",
            "15. What does 'See you tomorrow' mean?"
        };

        private int currentQuestionIndex = 0;
        private int score = 0;

        private readonly string[] levels = { "A1", "A2", "B1", "B2", "C1", "C2" };

        public string? UserLevel { get; private set; } = null;

        public LevelTestWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
            ShowChoiceOptions();
        }

        
        private void ShowChoiceOptions()
        {
            QuestionPanel.Children.Clear();

            TextBlock tb = new TextBlock
            {
                Text = "How would you like to determine your English level?",
                FontSize = 16,
                Margin = new Thickness(0, 0, 0, 20),
                TextAlignment = TextAlignment.Center
            };
            QuestionPanel.Children.Add(tb);

            StackPanel buttonsPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            Button chooseLevelBtn = new Button
            {
                Content = "I know my level",
                Width = 180,
                Height = 35,
                Background = System.Windows.Media.Brushes.Green,
                Foreground = System.Windows.Media.Brushes.White,
                Margin = new Thickness(0, 0, 15, 0)
            };
            chooseLevelBtn.Click += (s, e) => ShowLevelSelection();

            Button takeTestBtn = new Button
            {
                Content = "Take the Test",
                Width = 150,
                Height = 35,
                Background = System.Windows.Media.Brushes.Blue,
                Foreground = System.Windows.Media.Brushes.White
            };
            takeTestBtn.Click += (s, e) => ShowQuestion();

            buttonsPanel.Children.Add(chooseLevelBtn);
            buttonsPanel.Children.Add(takeTestBtn);

            QuestionPanel.Children.Add(buttonsPanel);
        }

        
        private void ShowLevelSelection()
        {
            QuestionPanel.Children.Clear();

            TextBlock tb = new TextBlock
            {
                Text = "Select your English level:",
                FontSize = 16,
                Margin = new Thickness(0, 0, 0, 10),
                TextAlignment = TextAlignment.Center
            };
            QuestionPanel.Children.Add(tb);

            ComboBox cb = new ComboBox
            {
                Name = "LevelComboBox",
                Width = 200,
                Height = 30,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            foreach (var level in levels)
                cb.Items.Add(level);

            QuestionPanel.Children.Add(cb);

            Button confirmBtn = new Button
            {
                Content = "Confirm Level",
                Width = 150,
                Height = 35,
                Margin = new Thickness(0, 10, 0, 0),
                Background = System.Windows.Media.Brushes.Green,
                Foreground = System.Windows.Media.Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            confirmBtn.Click += ConfirmLevel_Click;

            QuestionPanel.Children.Add(confirmBtn);
        }

        private void ConfirmLevel_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionPanel.Children[1] is ComboBox cb && cb.SelectedIndex >= 0)
            {
                int idx = cb.SelectedIndex;
                UserLevel = levels[idx];          
                currentUser.Level = idx + 1;    
                UserStorage.Save(currentUser);

                MessageBox.Show($"Your level: {UserLevel}", "Level Confirmed",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a level!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

       
        private void ShowQuestion()
        {
            QuestionPanel.Children.Clear();

            if (currentQuestionIndex < questions.Count)
            {
                TextBlock tb = new TextBlock
                {
                    Text = questions[currentQuestionIndex],
                    FontSize = 16,
                    Margin = new Thickness(0, 0, 0, 10),
                    TextWrapping = TextWrapping.Wrap,
                    Width = 400
                };
                QuestionPanel.Children.Add(tb);

                TextBox answerBox = new TextBox
                {
                    Width = 400,
                    Height = 30,
                    Name = "AnswerBox"
                };
                QuestionPanel.Children.Add(answerBox);

                Button nextBtn = new Button
                {
                    Content = currentQuestionIndex == questions.Count - 1 ? "Finish" : "Next",
                    Width = 120,
                    Height = 35,
                    Background = System.Windows.Media.Brushes.Blue,
                    Foreground = System.Windows.Media.Brushes.White,
                    Margin = new Thickness(0, 10, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                nextBtn.Click += NextQuestion_Click;
                QuestionPanel.Children.Add(nextBtn);
            }
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionPanel.Children.Count > 1 && QuestionPanel.Children[1] is TextBox tb)
            {
                string answer = tb.Text;
                if (!string.IsNullOrWhiteSpace(answer))
                    score += 1;
            }

            currentQuestionIndex++;
            if (currentQuestionIndex >= questions.Count)
            {
                CalculateLevel();
            }
            else
            {
                ShowQuestion();
            }
        }

        private void CalculateLevel()
        {
            int idx = score * levels.Length / questions.Count;
            if (idx >= levels.Length) idx = levels.Length - 1;

            UserLevel = levels[idx];      
            currentUser.Level = idx + 1;   
            UserStorage.Save(currentUser);

            MessageBox.Show($"Test completed! Your level: {UserLevel}", "Level Determined",
                MessageBoxButton.OK, MessageBoxImage.Information);

            this.DialogResult = true;
            this.Close();
        }
    }
}