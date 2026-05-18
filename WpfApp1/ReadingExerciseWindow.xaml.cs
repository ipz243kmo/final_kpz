using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfApp1
{
    public partial class ReadingExerciseWindow : Window
    {
        private Button selectedButton = null;

        private Dictionary<string, string> engTexts = new Dictionary<string, string>
        {
            { "Text 1", @"I wake up every morning at seven o’clock.
I brush my teeth and wash my face.
Then I have breakfast with my family.
I usually eat bread, eggs, and tea.
After breakfast, I go to school by bus.
My school starts at eight o’clock.
I study math, English, and science.
At noon, I have lunch in the school cafeteria.
In the afternoon, I have physical education and art classes.
School ends at three o’clock.
I return home and do my homework.
Then I play with my friends or read a book.
In the evening, I have dinner with my family.
After dinner, I watch TV or listen to music.
I go to bed at ten o’clock and sleep well." },

            { "Text 2", @"Last Sunday, I went to the park with my friends.
The weather was sunny and warm.
We walked along the lake and fed the ducks.
I brought a picnic basket with sandwiches and juice.
We sat on a blanket under a big tree.
We played football and ran on the grass.
Children were riding bicycles and playing with a ball.
We saw some people painting pictures and reading books.
I took many photos with my camera.
We drank cold lemonade to stay cool.
In the afternoon, we went to the playground.
I climbed the slides and swings many times.
We laughed and talked about school and hobbies.
The sun began to set, and it became cooler.
We went home tired but happy." },

            { "Text 3", @"My favorite hobby is painting.
I like to use watercolors and pencils.
I usually paint in the evening after school.
I have a small table with all my supplies.
I often draw landscapes, animals, and flowers.
Sometimes I paint portraits of my family members.
I watch tutorials online to learn new techniques.
Painting makes me feel relaxed and happy.
I enjoy mixing colors and creating new shades.
My friends like my paintings and sometimes ask for them.
I keep my best works in a special folder.
On weekends, I attend art classes in the city.
The teacher shows us how to improve our skills.
I hope one day to have my own art exhibition.
Painting is a way to express my feelings and ideas." },

            { "Text 4", @"Last summer, I visited the zoo with my family.
The zoo is very large and has many animals.
First, we saw the lions and tigers in their cages.
They were sleeping under the trees.
Then we visited the monkeys and watched them play.
Some monkeys were eating bananas and jumping around.
We also saw elephants, giraffes, and zebras.
The elephants were spraying water on themselves.
My little brother liked the penguins the most.
We took photos of the colorful birds in the aviary.
After walking for a while, we had ice cream near the lake.
We fed some fish and ducks in the pond.
The zoo guide told us interesting facts about the animals.
In the afternoon, we went to the gift shop and bought souvenirs.
We went home happy and talked about the animals we saw." }
        };

        private string currentText = "";

        public ReadingExerciseWindow()
        {
            InitializeComponent();

            SetFancyButton(EngToUkrBtn, Colors.OrangeRed, Colors.DarkRed);
            SetFancyButton(UkrToEngBtn, Colors.SeaGreen, Colors.DarkGreen);
            SetFancyButton(TextQuestionBtn, Colors.RoyalBlue, Colors.MediumBlue);

            TextSelectionPanel.Visibility = Visibility.Collapsed;
            TranslationBox.Visibility = Visibility.Collapsed;
        }

        private void SetFancyButton(Button btn, Color startColor, Color endColor)
        {
            btn.Background = new LinearGradientBrush(startColor, endColor, 45);
            btn.Foreground = Brushes.White;
            btn.FontWeight = FontWeights.Bold;
            btn.FontSize = 16;
            btn.BorderThickness = new Thickness(0);
            btn.Cursor = System.Windows.Input.Cursors.Hand;

            btn.RenderTransform = new ScaleTransform(1.0, 1.0);
            btn.RenderTransformOrigin = new Point(0.5, 0.5);

            btn.MouseEnter += (s, e) => AnimateScale(btn, 1.0, 1.05, 0.2);
            btn.MouseLeave += (s, e) => AnimateScale(btn, 1.05, 1.0, 0.2);
        }

        private void AnimateScale(Button btn, double from, double to, double durationSec)
        {
            ScaleTransform scale = (ScaleTransform)btn.RenderTransform;
            DoubleAnimation animX = new DoubleAnimation(from, to, TimeSpan.FromSeconds(durationSec));
            DoubleAnimation animY = new DoubleAnimation(from, to, TimeSpan.FromSeconds(durationSec));
            scale.BeginAnimation(ScaleTransform.ScaleXProperty, animX);
            scale.BeginAnimation(ScaleTransform.ScaleYProperty, animY);
        }

        private void TaskType_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                
                if (selectedButton != null && selectedButton != btn)
                {
                    selectedButton.BorderBrush = null;
                    selectedButton.BorderThickness = new Thickness(0);
                }

                btn.BorderBrush = Brushes.Gold;
                btn.BorderThickness = new Thickness(4);
                selectedButton = btn;

                if (btn == EngToUkrBtn)
                {
                    
                    ExerciseFormWindow exerciseWindow = new ExerciseFormWindow();
                    exerciseWindow.Owner = this; 
                    exerciseWindow.ShowDialog();
                }
                if (btn == UkrToEngBtn)
                {
                    
                    UkrToEngExerciseWindow exerciseWindow = new UkrToEngExerciseWindow();
                    exerciseWindow.Owner = this; 
                    exerciseWindow.ShowDialog(); 
                }
                if (btn == TextQuestionBtn)
                {
                  
                    ReadingTaskWindow exerciseWindow = new ReadingTaskWindow();
                    exerciseWindow.Owner = this;
                    exerciseWindow.ShowDialog(); 
                }
                else
                {
                   
                    ExercisePanel.Visibility = Visibility.Visible;
                }
            }
        }

        private void ShowTextSelection()
        {
            TextSelectionPanel.Children.Clear();
            TextSelectionPanel.Visibility = Visibility.Visible;
            TranslationBox.Visibility = Visibility.Collapsed;
            ExplanationBorder.Visibility = Visibility.Collapsed;

            foreach (var key in engTexts.Keys)
            {
                Button textBtn = new Button
                {
                    Content = key,
                    Width = 120,
                    Height = 50,
                    Margin = new Thickness(6),
                    Background = Brushes.LightBlue,
                    Foreground = Brushes.Black,
                    FontWeight = FontWeights.Bold,
                    BorderThickness = new Thickness(0),
                    Cursor = System.Windows.Input.Cursors.Hand
                };

                textBtn.Click += (s, e) => SelectText(key);
                TextSelectionPanel.Children.Add(textBtn);
            }
        }

        private void SelectText(string key)
        {
            currentText = engTexts[key];
            EnglishText.Text = currentText;
            TranslationBox.Text = "";
            TranslationBox.Visibility = Visibility.Visible;
            ExplanationBorder.Visibility = Visibility.Collapsed;
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentText))
                return;

            
            string translation = $"[Приклад перекладу тексту: {currentText.Substring(0, Math.Min(50, currentText.Length))}...]";
            ExplanationText.Text = translation;
            ExplanationBorder.Visibility = Visibility.Visible;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e) { }
    }
}