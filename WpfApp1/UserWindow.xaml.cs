using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class UserWindow : Window
    {
        private User currentUser;

        public User CurrentUser => currentUser;

        public UserWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            string[] levels = { "A1", "A2", "B1", "B2", "C1", "C2" };
            int levelIndex = Math.Clamp(currentUser.Level - 1, 0, levels.Length - 1);

            LoginText.Text = currentUser.Login;
            LevelText.Text = $"Рівень {levels[levelIndex]}";
            LevelProgress.Value = currentUser.Level;
            LessonsText.Text = currentUser.LessonsCompleted.ToString();
            TimeText.Text = $"{currentUser.StudyMinutes / 60} год {currentUser.StudyMinutes % 60} хв";

            if (!string.IsNullOrEmpty(currentUser.PhotoPath) && File.Exists(currentUser.PhotoPath))
            {
                UserImage.Source = new BitmapImage(new Uri(currentUser.PhotoPath));
            }
        }

        private void UploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.png)|*.jpg;*.png"
            };

            if (dialog.ShowDialog() == true)
            {
                currentUser.PhotoPath = dialog.FileName;
                UserImage.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void DetermineLevel_Click(object sender, RoutedEventArgs e)
        {
            LevelTestWindow levelWindow = new LevelTestWindow(currentUser);
            bool? result = levelWindow.ShowDialog();
            if (result == true)
                LoadUserData();
        }

        private void StartLearning_Click(object sender, RoutedEventArgs e)
        {
            RightPanel.Children.Clear();

            TextBlock tb = new TextBlock
            {
                Text = "Choose a topic to start learning:",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 10),
                TextAlignment = TextAlignment.Center
            };
            RightPanel.Children.Add(tb);

            List<string> topics = new List<string> { "Vocabulary", "Grammar (Tenses)", "Reading" };
            ComboBox topicComboBox = new ComboBox
            {
                Width = 250,
                Height = 30,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            foreach (var topic in topics)
                topicComboBox.Items.Add(topic);

            RightPanel.Children.Add(topicComboBox);

            Button startLessonBtn = new Button
            {
                Content = "Start Lesson",
                Width = 150,
                Height = 35,
                Margin = new Thickness(0, 10, 0, 0),
                Background = System.Windows.Media.Brushes.Green,
                Foreground = System.Windows.Media.Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            
            startLessonBtn.Click += (s, args) =>
            {
                if (topicComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a topic!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string selectedTopic = topics[topicComboBox.SelectedIndex];

                switch (selectedTopic)
                {
                    case "Grammar (Tenses)":
                        GrammarWindow grammarWindow = new GrammarWindow(currentUser);
                        grammarWindow.Show();
                        this.Hide();
                        break;

                    case "Reading":
                        ReadingExerciseWindow readingWindow = new ReadingExerciseWindow();
                        this.Hide(); 
                        readingWindow.ShowDialog();
                        this.Show(); 
                        UpdateStats();
                        break;

                    default:
                        LessonWindow lessonWindow = new LessonWindow(currentUser, selectedTopic);
                        lessonWindow.ShowDialog();
                        UpdateStats();
                        break;
                }
            };
            

            RightPanel.Children.Add(startLessonBtn);
        }
        private void UpdateStats()
        {
            TimeText.Text = $"{currentUser.StudyMinutes / 60} год {currentUser.StudyMinutes % 60} хв";
            LessonsText.Text = currentUser.LessonsCompleted.ToString();
        }

        private void StudyTheory_Click(object sender, RoutedEventArgs e)
        {
            TheoryWindow theoryWindow = new TheoryWindow();
            theoryWindow.ShowDialog();
        }
    }
}