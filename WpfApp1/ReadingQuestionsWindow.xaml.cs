using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class ReadingQuestionsWindow : Window
    {
        private string textKey;
        private string fullText;

        private Dictionary<string, string[]> textQuestions = new Dictionary<string, string[]>
        {
            { "My Daily Routine", new string[]
                {
                    "What time does the person wake up?",
                    "What does the person usually eat for breakfast?",
                    "How does the person go to school?",
                    "Name three subjects studied in the morning.",
                    "What happens at 10:30 a.m.?",
                    "What does the person do after school?",
                    "Which sports are mentioned?",
                    "At what time is dinner?",
                    "What does the person do in the evening?",
                    "What time does the person go to bed?"
                }
            },
            { "A Trip to the Zoo", new string[]
                {
                    "Who did the narrator go to the zoo with?",
                    "What was the weather like?",
                    "Which animals were seen first?",
                    "What were the monkeys doing?",
                    "What did the elephants do?",
                    "Which animal did the little brother like most?",
                    "Where did the family take photos?",
                    "What did they do near the lake?",
                    "What did they buy in the gift shop?",
                    "What time did they go home?"
                }
            },
            { "My Favorite Hobby", new string[]
                {
                    "What is the narrator's favorite hobby?",
                    "When does the narrator usually paint?",
                    "Name two tools or materials the narrator uses.",
                    "What types of drawings does the narrator make?",
                    "How does the narrator improve their skills?",
                    "Where does the narrator keep the best works?",
                    "Who asks the narrator to paint for them?",
                    "How does painting make the narrator feel?",
                    "When does the narrator attend art classes?",
                    "What does the narrator hope for in the future regarding painting?"
                }
            },
            { "A Visit to the Park", new string[]
                {
                    "Who did the narrator go to the park with?",
                    "What was the weather like?",
                    "What did the narrator bring for the picnic?",
                    "What activities did they do in the park?",
                    "Which playground equipment did the narrator use?",
                    "What did the children ride in the park?",
                    "What did the narrator photograph?",
                    "What did they drink to stay cool?",
                    "How did they feel at the end of the day?",
                    "What did they plan for next weekend?"
                }
            },
            { "A Summer Trip to the Beach", new string[]
                {
                    "Who went to the beach?",
                    "What time of day did they leave home?",
                    "What was the weather like?",
                    "What did the narrator do with the sand?",
                    "Which activity involved the sea?",
                    "What sports did they play?",
                    "Where did they have lunch?",
                    "What happened at sunset?",
                    "What did they collect as souvenirs?",
                    "How did the narrator feel about the trip?"
                }
            }
        };

        private Dictionary<string, string[]> sampleAnswers = new Dictionary<string, string[]>
        {
            { "My Daily Routine", new string[]
                {
                    "At 7 a.m.",
                    "Eggs, toast, and tea",
                    "By bus",
                    "English, Math, Science",
                    "Short break",
                    "Does homework, plays games",
                    "Basketball and football",
                    "At 7 p.m.",
                    "Watches TV or listens to music",
                    "At 10 p.m."
                }
            },
            { "A Trip to the Zoo", new string[]
                {
                    "With his family",
                    "Sunny and warm",
                    "Lions first",
                    "Playing and eating bananas",
                    "Spraying water with trunks",
                    "Penguins",
                    "Near the aviary",
                    "Fed ducks and fish",
                    "Souvenirs",
                    "6 p.m."
                }
            },
            { "My Favorite Hobby", new string[]
                {
                    "Painting",
                    "In the evening after school",
                    "Watercolors and pencils",
                    "Landscapes, animals, flowers, portraits",
                    "Watching tutorials online",
                    "In a special folder",
                    "Friends sometimes ask",
                    "Relaxed and happy",
                    "On weekends in the city",
                    "To have own art exhibition"
                }
            },
            { "A Visit to the Park", new string[]
                {
                    "With friends",
                    "Sunny and warm",
                    "Picnic basket with sandwiches and juice",
                    "Walking, playing football, climbing slides",
                    "Slides and swings",
                    "Bicycles",
                    "People painting pictures and reading",
                    "Cold lemonade",
                    "Tired but happy",
                    "Another visit next weekend"
                }
            },
            { "A Summer Trip to the Beach", new string[]
                {
                    "With family",
                    "Early in the morning",
                    "Sunny and bright",
                    "Built a sandcastle",
                    "Swimming in the sea",
                    "Beach volleyball",
                    "At a small café near the beach",
                    "Sunset turned sky orange and pink",
                    "Collected pebbles as souvenirs",
                    "Tired but happy"
                }
            }
        };

        public ReadingQuestionsWindow(string textKey, string fullText)
        {
            InitializeComponent();
            this.textKey = textKey;
            this.fullText = fullText;

            TextTitle.Text = $"Questions for \"{textKey}\"";
            GenerateQuestions();
        }

        private void GenerateQuestions()
        {
            if (!textQuestions.ContainsKey(textKey)) return;

            QuestionsPanel.Children.Clear();

            string[] questions = textQuestions[textKey];
            string[] answers = sampleAnswers.ContainsKey(textKey) ? sampleAnswers[textKey] : new string[questions.Length];

            for (int i = 0; i < questions.Length; i++)
            {
                StackPanel questionPanel = new StackPanel { Margin = new Thickness(0, 0, 0, 20) };

                TextBlock questionText = new TextBlock
                {
                    Text = $"Question {i + 1}: {questions[i]}",
                    FontSize = 16,
                    TextWrapping = TextWrapping.Wrap
                };

                TextBox answerBox = new TextBox
                {
                    Width = 600,
                    Height = 30,
                    Margin = new Thickness(0, 5, 0, 0)
                };

                TextBlock correctAnswerText = new TextBlock
                {
                    FontSize = 14,
                    Foreground = System.Windows.Media.Brushes.DarkBlue,
                    Margin = new Thickness(0, 5, 0, 0),
                    Visibility = Visibility.Collapsed
                };

                Button checkBtn = new Button
                {
                    Content = "Перевірити",
                    Width = 100,
                    Height = 25,
                    Margin = new Thickness(5, 5, 0, 0)
                };

                int index = i; 
                checkBtn.Click += (s, e) =>
                {
                    correctAnswerText.Text = $"Приклад відповіді: {answers[index]}";
                    correctAnswerText.Visibility = Visibility.Visible;
                };

                StackPanel answerPanel = new StackPanel { Orientation = Orientation.Horizontal };
                answerPanel.Children.Add(answerBox);
                answerPanel.Children.Add(checkBtn);

                questionPanel.Children.Add(questionText);
                questionPanel.Children.Add(answerPanel);
                questionPanel.Children.Add(correctAnswerText);

                QuestionsPanel.Children.Add(questionPanel);
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Всі відповіді збережено.", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}