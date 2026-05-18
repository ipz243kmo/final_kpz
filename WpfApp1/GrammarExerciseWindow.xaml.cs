using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class GrammarExerciseWindow : Window
    {
        private readonly List<GrammarExercise> exercises;
        private int index = 0;
        private int score = 0;
        private string selectedWord = "";

        public GrammarExerciseWindow(List<GrammarExercise> exercisesList)
        {
            InitializeComponent();
            exercises = exercisesList ?? new List<GrammarExercise>();
            LoadExercise();
        }

        private void LoadExercise()
        {
            ResultText.Text = "";
            WordsPanel.Children.Clear();
            if (DropZone != null) DropZone.BorderBrush = Brushes.Gray;
            selectedWord = "";
            NextButton.Visibility = Visibility.Hidden;

            if (index >= exercises.Count) return;

            var ex = exercises[index];
            SentenceText.Text = ex.SentenceTemplate ?? "";
            ProgressText.Text = $"{index + 1}/{exercises.Count}";
            ScoreText.Text = score.ToString();

            if (ex.Options == null || ex.Options.Length == 0)
            {
                ResultText.Foreground = Brushes.Red;
                ResultText.Text = "❌ Варіанти для цього завдання не задані.";
                return;
            }

            foreach (var word in ex.Options)
            {
                Border card = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(160, 200, 240)),
                    CornerRadius = new CornerRadius(8),
                    Margin = new Thickness(8),
                    Padding = new Thickness(15),
                    Cursor = Cursors.Hand,
                    MinWidth = 100,
                    MinHeight = 40
                };

                TextBlock text = new TextBlock
                {
                    Text = word,
                    FontSize = 18,
                    Foreground = Brushes.Black,
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                card.Child = text;
                card.MouseMove += Word_MouseMove;
                WordsPanel.Children.Add(card);
            }
        }

        private void Word_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Border border && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(border, ((TextBlock)border.Child).Text, DragDropEffects.Move);
            }
        }

        private void DropZone_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
            e.Handled = true;
        }

        private void DropZone_Drop(object sender, DragEventArgs e)
        {
            selectedWord = e.Data.GetData(typeof(string))?.ToString() ?? "";
            var template = exercises[index].SentenceTemplate ?? "";
            SentenceText.Text = template.Replace("____", selectedWord);
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (index >= exercises.Count) return;

            var ex = exercises[index];

            if (ex.CorrectWords == null || ex.CorrectWords.Length == 0)
            {
                ResultText.Foreground = Brushes.Red;
                ResultText.Text = "❌ Для цього завдання правильні відповіді не задані.";
                ExplanationBorder.Visibility = Visibility.Collapsed;
                return;
            }

            if (string.IsNullOrEmpty(selectedWord))
            {
                ResultText.Foreground = Brushes.Orange;
                ResultText.Text = "⚠️ Оберіть слово перед перевіркою.";
                ExplanationBorder.Visibility = Visibility.Collapsed;
                return;
            }

            if (selectedWord == ex.CorrectWords[0])
            {
                score++;
                ResultText.Foreground = Brushes.Green;
                ResultText.Text = "✅ Правильно!";
                ExplanationBorder.Background = new SolidColorBrush(Color.FromRgb(198, 239, 206)); 
                ExplanationText.Text = ex.Explanation; 
            }
            else
            {
                if (DropZone != null) DropZone.BorderBrush = Brushes.Red;
                ResultText.Foreground = Brushes.Red;
                ResultText.Text = "❌ Неправильно";
                ExplanationBorder.Background = new SolidColorBrush(Color.FromRgb(255, 199, 206)); 
                ExplanationText.Text = $"Правильна відповідь: {ex.CorrectWords[0]}\n\nПояснення: {ex.Explanation}";
            }

            ExplanationBorder.Visibility = Visibility.Visible;
            ScoreText.Text = score.ToString();
            NextButton.Visibility = Visibility.Visible;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            index++;
            if (index < exercises.Count)
            {
                LoadExercise();
                NextButton.Visibility = Visibility.Hidden;
            }
            else
            {
                ResultText.Text = $"🎉 Вправи завершено!\nПравильних відповідей: {score}/{exercises.Count}";
                NextButton.Visibility = Visibility.Hidden;
            }
        }

        private void AnimateSuccess()
        {
            if (DropZone == null) return;

            SolidColorBrush brush = new SolidColorBrush(Colors.White);
            DropZone.Background = brush;

            ColorAnimation animation = new ColorAnimation
            {
                From = Colors.LightGreen,
                To = Colors.White,
                Duration = new Duration(System.TimeSpan.FromSeconds(0.6))
            };
            brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }
    }
}